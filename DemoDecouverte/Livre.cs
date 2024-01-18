using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDecouverte
{
    internal class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string Auteur { get; set; }
        public DateTime DatePublication { get; set; }
    }
}
