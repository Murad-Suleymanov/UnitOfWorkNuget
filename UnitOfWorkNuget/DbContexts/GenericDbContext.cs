using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using System.Reflection.Emit;
using System.Configuration;

namespace UnitOfWorkNuget.DbContexts
{
    public class GenericDbContext : DbContext
    {
        readonly string conStrName = string.Empty;

        public GenericDbContext(string conStrName)
        {
            this.conStrName = conStrName;
            this.Database.Migrate();
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public GenericDbContext(DbContextOptions<GenericDbContext> options) : base(options)
        {
            this.Database.Migrate();
            ChangeTracker.LazyLoadingEnabled = false;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager
                 .ConnectionStrings[conStrName]
                 .ConnectionString;

            optionsBuilder.UseSqlServer(connectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly assembly in assemblies)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
