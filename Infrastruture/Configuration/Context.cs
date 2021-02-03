using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastruture.Configuration
{
    public class Context : DbContext

    {
        public DbSet<Product> Products { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {
            //Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ser nao estiver configurado no projeto IU pega a deginicao de chame do json configurado
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConectionCofig());
            }
            base.OnConfiguring(optionsBuilder);
        }

        private string GetStringConectionCofig()
        {
            string strCon = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BaseDDD_Migration;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return strCon;
        }
    }
}
