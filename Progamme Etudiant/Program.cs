using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using Progamme_Etudiant;
using static System.Net.Mime.MediaTypeNames;





class Program
{


    static List<Etudiant> listeEtudiants = new List<Etudiant>();

    static void Main()
    {
        while (true)
        {
            AfficherMenu();

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    SaisirEtudiant();
                    break;
                case "2":
                    AfficherTousEtudiants();
                    break;
                case "3":
                    AfficherEtudiantsClasse();
                    break;
                case "4":
                    SupprimerEtudiant();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Choix invalide. Veuillez réessayer.");
                    break;
            }
        }
    }

    static void AfficherMenu()
    {
        Console.WriteLine("\nMenu :");
        Console.WriteLine("1. Ajouter un étudiant");
        Console.WriteLine("2. Afficher tous les étudiants");
        Console.WriteLine("3. Afficher les étudiants d'une classe");
        Console.WriteLine("4. Supprimer un étudiant");
        Console.WriteLine("0. Quitter");
        Console.Write("Choisissez une option : ");
    }

    static void SaisirEtudiant()
    {
        Etudiant etudiant = new Etudiant();

        Console.Write("Entrez le nom de l'étudiant : ");
        etudiant.Nom = Console.ReadLine();

        Console.Write("Entrez le prénom de l'étudiant : ");
        etudiant.Prenom = Console.ReadLine();

        Console.Write("Entrez le numéro de classe de l'étudiant : ");
        etudiant.NumeroDeClasse = Console.ReadLine();

        Console.Write("Entrez la date de diplôme de l'étudiant : ");
        etudiant.dateDeDiplome = Console.ReadLine();

        listeEtudiants.Add(etudiant);


        string connectionString = "Data Source=(localdb)\\BDD_ADO; Initial Catalog = dbEtudiant; Integrated Security = True; Connect Timeout = 30; Encrypt = True; Trust Server Certificate=False; Application Intent = ReadWrite; Multi Subnet Failover=False";


        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO etudiant (nom, prenom, numeroDeClasse, dateDeDiplome) VALUES (@Nom, @Prenom, @NumeroDeClasse, @dateDeDiplome)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nom", etudiant.Nom);
                command.Parameters.AddWithValue("@Prenom", etudiant.Prenom);
                command.Parameters.AddWithValue("@NumeroDeClasse", etudiant.NumeroDeClasse);
                command.Parameters.AddWithValue("@dateDeDiplome", etudiant.dateDeDiplome);

                command.ExecuteNonQuery();
            }
            Console.WriteLine("Enregistrement ajouté avec succès!\n");

        }
    }

    static void AfficherTousEtudiants()
    {
        Console.WriteLine("\nListe des étudiants :");
        foreach (var etudiant in listeEtudiants)
        {
            Console.WriteLine($"Nom : {etudiant.Nom}, Prénom : {etudiant.Prenom}, Numéro de classe : {etudiant.NumeroDeClasse}, Date de diplôme : {etudiant.dateDeDiplome}");
        }
    }


    static void AfficherEtudiantsClasse()
    {
        Console.Write("Entrez le numéro de classe : ");
        string classe = Console.ReadLine();

        var etudiantsClasse = listeEtudiants.Where(e => e.NumeroDeClasse == classe).ToList();

        if (etudiantsClasse.Count > 0)
        {
            Console.WriteLine($"\nListe des étudiants de la classe {classe} :");
            foreach (var etudiant in etudiantsClasse)
            {
                Console.WriteLine($"Nom : {etudiant.Nom}, Prénom : {etudiant.Prenom}, Date de diplôme : {etudiant.dateDeDiplome}");
            }
        }
        else
        {
            Console.WriteLine($"Aucun étudiant trouvé pour la classe {classe}.\n");
        }
    }

    static void SupprimerEtudiant()
    {
        Console.Write("Entrez le nom de l'étudiant à supprimer : ");
        string nomSupprimer = Console.ReadLine();

        var etudiantSupprimer = listeEtudiants.FirstOrDefault(e => e.Nom == nomSupprimer);

        if (etudiantSupprimer != null)
        {
            listeEtudiants.Remove(etudiantSupprimer);
            Console.WriteLine($"L'étudiant {nomSupprimer} a été supprimé avec succès.\n");
        }
        else
        {
            Console.WriteLine($"Aucun étudiant trouvé avec le nom {nomSupprimer}.\n");
        }
    }

}
 