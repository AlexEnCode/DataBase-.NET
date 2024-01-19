using Creation_de_personnage.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creation_de_personnage.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {
        }

        public DbSet<Personnage> Personnages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data source=(localdb)\\MSSQLLocalDB; Database=Personnage;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Personnage>().HasData(new Personnage()
            {
                Id = 1,
                Pseudo = "AlexHam",
                PointDeVie = 12,
                Armure = 4,
                Degats = 6,
                DateCreation = DateTime.Now,
                NombreVictime = 0
            });
        }
    }
}