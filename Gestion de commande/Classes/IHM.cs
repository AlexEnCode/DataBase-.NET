using Gestion_de_commande.DAO;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_commande.Classes
{
    internal class IHM
    {


        public void AfficherTitre()
        {
            Console.WriteLine(@"
   ____                                          _           
  / ___|___  _ __ ___  _ __ ___   __ _ _ __   __| | ___  ___ 
 | |   / _ \| '_ ` _ \| '_ ` _ \ / _` | '_ \ / _` |/ _ \/ __|
 | |__| (_) | | | | | | | | | | | (_| | | | | (_| |  __/\__ \
  \____\___/|_| |_| |_|_| |_| |_|\__,_|_| |_|\__,_|\___||___/
");


            Console.WriteLine("\n1. Lister les clients");
            Console.WriteLine("2. Créer un client");
            Console.WriteLine("3. Modifier un client");
            Console.WriteLine("4. Supprimer un client");
            Console.WriteLine("5. Afficher les détails d'un client");
            Console.WriteLine("6. Ajouter une commande");
            Console.WriteLine("0. Quitter");
        }

        public void AfficherMenu()
        {
           
            while (true)
            {
                

                Console.Write("Choisissez une option : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        Afficher();
                        break;
                    case "2":
                        Ajouter();

                        break;
                    case "3":
                        Editer();
                        break;
                    case "4":
                        Supprimer();
                        break;
                    case "5":
                        Detail();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Option non valide. Veuillez réessayer.");
                        break;
                }
            }
        }


 ClientDAO clientDAO = new ClientDAO();

        public void Afficher()
        {
           
           // ClientDAO.AfficherTousLesClients();
        }

        public void Ajouter()
        {
            ClientDAO client = new();
            ClientDAO.AjouterClient(client);
        }
        public void Editer()
        {
            //  ClientDAO.EditerClient();
        }
        public void Supprimer()
        {
            //  ClientDAO.SupprimerClient();
        }
        public void Detail()
        {
            //   ClientDAO.AfficherDetailClient();
        }
    }

}

