using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDecouverte
{
    // DbContext permet de communiquer entre modele et BDD
    internal class DecouverteDbContext : DbContext
    {
        // dans une app sans injection de dependance, on utilise ce constructeur
        public DecouverteDbContext() : base()
        {
        }

        // Métode appelée lors de la configuration d'EFCore à notre application
        protected override void OnConfiguring(DbContextOptionBuilder optionsBuilder)
        {
            // la métode optionBuilder pour lui expliquer que nous allons utiliser une BDD SQLServer
            optionsBuilder.UseSqlServer("Data source=(localdb)\\");
        }
    }
}
