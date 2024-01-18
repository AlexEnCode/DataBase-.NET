using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Creation_de_personnage.Models
{
    internal class Personnage
    {


        public int Id { get; set; }
        public string Pseudo { get; set; }
        public int? PointDeVie { get; set; }
        public int? Armure { get; set; }
        public int? Degats { get; set; }
        public DateTime DateCreation { get; set; }
        public int? NombreVictime { get; set; }
    
    
    
    }
}
