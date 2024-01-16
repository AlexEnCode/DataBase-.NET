using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using Progamme_Etudiant;
using static System.Net.Mime.MediaTypeNames;


string connectionString = "Data Source=(localdb)\\BDD_ADO; Initial Catalog = dbEtudiant; Integrated Security = True; Connect Timeout = 30; Encrypt = True; Trust Server Certificate=False; Application Intent = ReadWrite; Multi Subnet Failover=False";

List<Etudiant> listeEtudiants = new List<Etudiant>();


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


void AfficherMenu()
{
    Console.WriteLine("\nMenu :");
    Console.WriteLine("1. Ajouter un étudiant");
    Console.WriteLine("2. Afficher tous les étudiants");
    Console.WriteLine("3. Afficher les étudiants d'une classe");
    Console.WriteLine("4. Supprimer un étudiant");
    Console.WriteLine("0. Quitter");
    Console.Write("Choisissez une option : ");
}

void SaisirEtudiant()
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



    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();

        string query = "INSERT INTO etudiant (nom, prenom, numeroDeClasse, dateDeDiplome) VALUES (@Nom, @Prenom, @NumeroDeClasse, @dateDeDiplome)";

        SqlCommand command = new SqlCommand(query, connection);
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

void AfficherTousEtudiants()
{
    Console.WriteLine("\nListe des étudiants :");
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();

        string query = "SELECT nom, prenom, numeroDeClasse, dateDeDiplome FROM etudiant";

        SqlCommand command = new SqlCommand(query, connection);
        {
            SqlDataReader reader = command.ExecuteReader();
            {
                while (reader.Read())
                {
                    string nom = reader.GetString(0);
                    string prenom = reader.GetString(1);
                    string numeroDeClasse = reader.GetString(2);
                    string dateDeDiplome = reader.GetString(3);

                    Console.WriteLine($"Nom : {nom}, Prénom : {prenom}, Numéro de classe : {numeroDeClasse}, Date de diplôme : {dateDeDiplome}");
                }
            }
        }
    }
}

void AfficherEtudiantsClasse()
{
    Console.Write("Entrez le numéro de classe : ");

    string numeroDeClasse = Console.ReadLine();

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();

        string query = "SELECT nom, prenom, dateDeDiplome FROM etudiant WHERE @numeroDeClasse = numeroDeClasse";

        SqlCommand command = new SqlCommand(query, connection);
        {
            command.Parameters.AddWithValue("@numeroDeClasse", numeroDeClasse);

            int rowsAffected = command.ExecuteNonQuery();

            Console.WriteLine($"\nListe des étudiants de la classe {numeroDeClasse} :");

            {
                SqlDataReader reader = command.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        string nom = reader.GetString("nom");
                        string prenom = reader.GetString("prenom");
                        string dateDeDiplome = reader.GetString("dateDeDiplome");

                        Console.WriteLine($"Nom : {nom}, Prénom : {prenom}, Numéro de classe : {numeroDeClasse}, Date de diplôme : {dateDeDiplome}");
                    }
                }
            }
        }
    }
}

void SupprimerEtudiant()
{
    Console.Write("Entrez le nom de l'étudiant à supprimer : ");
    string nomEtudiant = Console.ReadLine();

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();

        string query = "DELETE FROM etudiant WHERE @Nom = nom";

        SqlCommand command = new SqlCommand(query, connection);
        {
            command.Parameters.AddWithValue("@Nom", nomEtudiant);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine($"L'étudiant avec le nom {nomEtudiant} a été supprimé avec succès!");
            }
            else
            {
                Console.WriteLine($"Aucun étudiant trouvé avec le nom {nomEtudiant}.");
            }
        }
    }
}
