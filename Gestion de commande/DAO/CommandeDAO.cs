using Gestion_de_commande.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_commande.DAO
{
    internal class CommandeDAO
    {

        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=commande;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";


        public void AjouterCommande(int clientId, Commande commande)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Commande (ClientID, Date, Total) " +
                               "VALUES (@ClientID, @Date, @Total)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientID", clientId);
                    command.Parameters.AddWithValue("@Date", commande.Date);
                    command.Parameters.AddWithValue("@Total", commande.Total);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
