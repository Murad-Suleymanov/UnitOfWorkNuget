using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    //internal class CategoryConfig : IEntityTypeConfiguration<Category>
    //{
    //    public void Configure(EntityTypeBuilder<Category> builder)
    //    {
    //        builder.HasKey(x => x.Id);
    //        builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
    //        builder.Property(x => x.Id).HasColumnName("Id");
    //        builder.Property(x => x.Name).HasColumnName("Name");

    //        builder.ToTable("Category");
    //    }
    //}
}
