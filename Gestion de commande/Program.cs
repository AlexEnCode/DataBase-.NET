using System;
using System.Data.SqlClient;




Console.WriteLine(@"
   ____                                          _           
  / ___|___  _ __ ___  _ __ ___   __ _ _ __   __| | ___  ___ 
 | |   / _ \| '_ ` _ \| '_ ` _ \ / _` | '_ \ / _` |/ _ \/ __|
 | |__| (_) | | | | | | | | | | | (_| | | | | (_| |  __/\__ \
  \____\___/|_| |_| |_|_| |_| |_|\__,_|_| |_|\__,_|\___||___/

");


while (true)
{
    AfficherMenu();

    Console.Write("Choisissez une option : ");
    string choix = Console.ReadLine();

    switch (choix)
    {
        case "1":
            AfficherTousLesClients();
            break;
        case "2":
            CreerClient();
            break;
        case "3":
            ModifierClient();
            break;
        case "4":
            SupprimerClient();
            break;
        case "5":
            AfficherDetailsClient();
            break;
        case "6":
            AjouterCommande();
            break;
        case "7":
            ModifierCommande();
            break;
        case "8":
            SupprimerCommande();
            break;
        case "0":
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Option non valide. Veuillez réessayer.");
            break;
    }
}




