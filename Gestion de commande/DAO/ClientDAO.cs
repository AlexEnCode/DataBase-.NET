﻿using Gestion_de_commande.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_commande.DAO
{
    internal class ClientDAO
    {




        public string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=commande;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public void AfficherTousLesClients()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ID, Nom, Prenom FROM Client";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["ID"]}: {reader["Prenom"]} {reader["Nom"]}");
                        }
                    }
                }
            }
        }

        public void AjouterClient(Client client)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Client (Nom, Prenom, Adresse, CodePostal, Ville, Telephone) " +
                               "VALUES (@Nom, @Prenom, @Adresse, @CodePostal, @Ville, @Telephone)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nom", client.Nom);
                    command.Parameters.AddWithValue("@Prenom", client.Prenom);
                    command.Parameters.AddWithValue("@Adresse", client.Adresse);
                    command.Parameters.AddWithValue("@CodePostal", client.CodePostal);
                    command.Parameters.AddWithValue("@Ville", client.Ville);
                    command.Parameters.AddWithValue("@Telephone", client.Telephone);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditerClient(int clientId, Client nouveauClient)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Client SET Nom = @Nom, Prenom = @Prenom, " +
                               "Adresse = @Adresse, CodePostal = @CodePostal, " +
                               "Ville = @Ville, Telephone = @Telephone WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", clientId);
                    command.Parameters.AddWithValue("@Nom", nouveauClient.Nom);
                    command.Parameters.AddWithValue("@Prenom", nouveauClient.Prenom);
                    command.Parameters.AddWithValue("@Adresse", nouveauClient.Adresse);
                    command.Parameters.AddWithValue("@CodePostal", nouveauClient.CodePostal);
                    command.Parameters.AddWithValue("@Ville", nouveauClient.Ville);
                    command.Parameters.AddWithValue("@Telephone", nouveauClient.Telephone);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void SupprimerClient(int clientId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteCommandeQuery = "DELETE FROM Commande WHERE ClientID = @ClientID";
                string deleteClientQuery = "DELETE FROM Client WHERE ID = @ID";

                using (SqlCommand deleteCommandeCommand = new SqlCommand(deleteCommandeQuery, connection))
                {
                    deleteCommandeCommand.Parameters.AddWithValue("@ClientID", clientId);
                    deleteCommandeCommand.ExecuteNonQuery();
                }

                using (SqlCommand deleteClientCommand = new SqlCommand(deleteClientQuery, connection))
                {
                    deleteClientCommand.Parameters.AddWithValue("@ID", clientId);
                    deleteClientCommand.ExecuteNonQuery();
                }
            }
        }

        public void AfficherDetailClient(int clientId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string clientQuery = "SELECT ID, Nom, Prenom, Adresse, CodePostal, Ville, Telephone " +
                                     "FROM Client WHERE ID = @ID";

                string commandeQuery = "SELECT ID, Date, Total FROM Commande WHERE ClientID = @ClientID";

                using (SqlCommand clientCommand = new SqlCommand(clientQuery, connection))
                {
                    clientCommand.Parameters.AddWithValue("@ID", clientId);

                    using (SqlDataReader clientReader = clientCommand.ExecuteReader())
                    {
                        if (clientReader.Read())
                        {
                            Console.WriteLine($"ID: {clientReader["ID"]}");
                            Console.WriteLine($"Nom: {clientReader["Nom"]} {clientReader["Prenom"]}");
                            Console.WriteLine($"Adresse: {clientReader["Adresse"]}, {clientReader["CodePostal"]} {clientReader["Ville"]}");
                            Console.WriteLine($"Téléphone: {clientReader["Telephone"]}");
                            Console.WriteLine("Commandes:");
                        }
                    }
                }

                using (SqlCommand commandeCommand = new SqlCommand(commandeQuery, connection))
                {
                    commandeCommand.Parameters.AddWithValue("@ClientID", clientId);

                    using (SqlDataReader commandeReader = commandeCommand.ExecuteReader())
                    {
                        while (commandeReader.Read())
                        {
                            Console.WriteLine($"  - ID: {commandeReader["ID"]}, Date: {commandeReader["Date"]}, Total: {commandeReader["Total"]:C}");
                        }
                    }
                }
            }
        }

        internal static void AjouterClient(ClientDAO client)
        {
            throw new NotImplementedException();
        }
    }
}
    
