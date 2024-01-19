using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.SqlClient;



namespace Gestion_de_commande.Classes
{
    internal class Client
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Telephone { get; set; }

        public List<Commande> Commandes { get; set; }

        public override string ToString()
        {
            return $"Nom : {Prenom} {Nom}";
        }

        public Client(int iD, string nom, string prenom, string adresse, string codePostal, string ville, string telephone, List<Commande> commandes)
        {
            ID = iD;
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            CodePostal = codePostal;
            Ville = ville;
            Telephone = telephone;
            Commandes = commandes;
        }
      
    }
}