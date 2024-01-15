
using Microsoft.Data.SqlClient;
using System.Data;


string connectionString = "Data Source=(localdb)\\BDD_ADO ; Integrated Security=True; Database = BddAdo"; 

SqlConnection connection= new SqlConnection(connectionString);

connection.Open();

if(connection.State == ConnectionState.Open)
{
    Console.WriteLine("ça marche bien");
} 
else 
{ 
    Console.WriteLine("Nop. Sad");
}

// Requete
string prenom = Console.ReadLine() ?? "";
string nom = Console.ReadLine() ?? "";
string email = Console.ReadLine() ?? "";
string requete = $"INSERT INTO personne (prenom, nom, email) VALUES ('{prenom}','{nom}','{email}')";

// On instancie un objet de type commande qui contiendra la requete, la connection ainsi qu'une transaction si necessaire.
SqlCommand command = new SqlCommand(requete, connection);

// ExecuteNonQuery revoie le nombre d'element affectés
int rowsAffected = command.ExecuteNonQuery();


Console.WriteLine(rowsAffected);

command.Dispose();

connection.Close();