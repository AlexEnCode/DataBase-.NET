using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.SqlClient;



namespace Gestion_de_commande
{
    internal class Commande
    {

        public int ID { get; set; }
        public int ClientID { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }

        public Client Client { get; set; }


        public Commande(int iD, int clientID, DateTime date, decimal total, Client client)
        {
            ID = iD;
            ClientID = clientID;
            Date = date;
            Total = total;
            Client = client;
        }

    }
}