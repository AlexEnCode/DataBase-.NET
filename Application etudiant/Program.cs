using System;
using System.Collections.Generic;
using System.Linq;

class Etudiant
{
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string NumeroClasse { get; set; }
    public string DateDiplome { get; set; }
}

class Program
{
    static List<Etudiant> listeEtudiants = new List<Etudiant>();

    static void Main()
    {
       
    }

    static void AfficherMenu()
    {
        Console.WriteLine("\nMenu :");
        Console.WriteLine("1. Ajouter un étudiant");
        Console.WriteLine("2. Afficher tous les étudiants");
        Console.WriteLine("3. Afficher les étudiants d'une classe");
        Console.WriteLine("4. Supprimer un étudiant");
        Console.WriteLine("5. Mettre à jour un étudiant (optionnel)");
        Console.WriteLine("6. Quitter");
        Console.Write("Choisissez une option : ");
    }

}
