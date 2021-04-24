using CozyLounge.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CozyLounge.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasSequence("PosSeq")
                .StartsAt(1)
                .IncrementsBy(1);


        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<CozyCodes> CozyCodes { get; set; }
        public DbSet<Dockets> Dockets { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<SalesPersons> SalesPersons { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

        //public DbSet<SalesPerson> SalesPersons { get; set; } 

    }
} 
