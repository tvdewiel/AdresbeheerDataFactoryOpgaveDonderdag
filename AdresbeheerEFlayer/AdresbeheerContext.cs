
using AdresbeheerEFlayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerEFlayer
{
    public class AdresbeheerContext : DbContext
    {
        private string connectionString;
        public DbSet<GemeenteEF> Gemeente {  get; set; }
        public DbSet<StraatEF> Straat { get; set; }
        public DbSet<AdresEF> Adres { get; set; }

        public AdresbeheerContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
