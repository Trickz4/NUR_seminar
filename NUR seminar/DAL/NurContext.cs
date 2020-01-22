using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUR.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NUR.DAL
{
    public class NurContext : DbContext
    {

        public NurContext() : base("NurContext")
        {
        }

        public DbSet<Programska> Programskas { get; set; }
        public DbSet<Strojna> Strojnas { get; set; }
        public DbSet<Prostorija> Prostorijas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}