using Example.Domain;
using System;
using System.Linq;
using UnitOfWorkNuget.Abstract;
using UnitOfWorkNuget.Repositories;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string conn = "EFDbContext";


            IUnitOfWork unitOfWork = new UnitOfWork(conn);

            var d = unitOfWork
                .Repository<NewCategory>()
                .AsQuaryable()
                .FirstOrDefault(c => c.Id == 1);


            var cd = unitOfWork
                .Repository<Product>()
                .AsQuaryable()
                .FirstOrDefault(c => c.ProductID == 1);

            Console.WriteLine(d.Name);
            Console.WriteLine(cd.Name);

            Console.Read();
        }
    }
}
