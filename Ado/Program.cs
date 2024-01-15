
using Microsoft.Data.SqlClient;
using System.Data;


string connectionString = "Data Source=(localdb)\\BDD_ADO ; Integrated Security=True; Database = BddAdo";

/*SqlConnection connection= new SqlConnection(connectionString);

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
command.CommandType = CommandType.Text;


// ExecuteNonQuery revoie le nombre d'element affectés
int rowsAffected = command.ExecuteNonQuery();


Console.WriteLine(rowsAffected);

// Libere la commande SQL
command.Dispose();

//Ferme la connection au serveur
connection.Close();
*/



/*

using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();
    string request = $"INSERT INTO personne (prenom, nom, email) VALUES (@prenom, @nom , @email)";

    // Syntaxe simplifée
    SqlCommand command = new SqlCommand(request, connection);

    // Syntaxe avec ka orecision du type
    command.Parameters.AddWithValue("@prenom", "lea");
    command.Parameters.Add("@nom", SqlDbType.VarChar);

    command.Parameters["@nom"].Value = "Dupont";

    try
    {
        connection.Open();
        int rowsAffected = command.ExecuteNonQuery();
        Console.WriteLine($"{rowsAffected} lignes affectées");
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
*/


using (SqlConnection connection = new SqlConnection(connectionString))
{
    string req = "SELECT id , nom, prenom, email FROM personne";


    SqlCommand command = new SqlCommand(req, connection);


    try
    {
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        while(reader.Read())
        {
            Console.WriteLine($" id: {reader.GetInt32(0)}, nom: {reader.GetString(1)}, prenom: { reader.GetString(2)}, email: { reader.GetString(3)}");
        }
    }
        catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}


using (SqlConnection connection = new SqlConnection(connectionString))
{
    string req = "SELECT AVG(LEN(prenom)) prenom FROM personne";


    SqlCommand command = new SqlCommand(req, connection);


    try
    {
        connection.Open();
        // si requete envoie un unique resultat on utilise ExecuteScalar => renvoie le resultat de la premiere ligne
        int averageFirstNameLength = (int)command.ExecuteScalar();
        Console.WriteLine($"la taille moyenne des prenom de la Table est de {averageFirstNameLength} char");

    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}