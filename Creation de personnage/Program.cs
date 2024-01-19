
using Creation_de_personnage.Data;
using Creation_de_personnage.Models;

using var context = new ApplicationDbContext();

var monPersonnage = new Personnage()
{
    Pseudo = "Kayus",
    PointDeVie = 10,
    Armure = 4,
    Degats = 6,
    DateCreation = DateTime.Now,
    NombreVictime = 1,
};

context.Personnages.Add(monPersonnage);
context.SaveChanges();

void CreerPersonnage()
{
    Console.Write("entrez le Pseudo :");
    string newPseudo = Console.ReadLine();
    Console.Write("entrez son Nombre de PV :");
    int newPdv = int.Parse(Console.ReadLine());
    Console.Write("entrez son Nombre de PA :");
    int newPA = int.Parse(Console.ReadLine());
    Console.Write("entrez son Nombre de AD :");
    int newAD = int.Parse(Console.ReadLine());
    Console.Write("entrez son Nombre de Victime :");
    int newNV = int.Parse(Console.ReadLine());

    var nouveauPersonnage = new Personnage
    {
        Pseudo = newPseudo,
        PointDeVie = newPdv,
        Armure = newPA,
        Degats = newAD,
        DateCreation = DateTime.Now,
        NombreVictime = newNV
    };

    context.Personnages.Add(nouveauPersonnage);
    context.SaveChanges();

    Console.WriteLine($"Le personnage {nouveauPersonnage.Pseudo}a été créé avec succès!");
}


void MettreAJourPersonnage()
{

    Console.Write("Entrez l' ID  du personnage à modifier :");
    int Pseudo = Convert.ToInt32(Console.ReadLine());
    var personnage = context.Personnages.Find(Pseudo);

    if (personnage != null)
    {
        Console.WriteLine($"Vous souhaitez modifier: {personnage.Pseudo}");
        Console.Write("entrez le nouveau Pseudo :");
        personnage.Pseudo = Console.ReadLine();
        Console.Write("entrez son nouveau Nombre de PV :");
        personnage.PointDeVie = int.Parse(Console.ReadLine());
        Console.Write("entrez son nouveau Nombre de PA :");
        personnage.Armure = int.Parse(Console.ReadLine());
        Console.Write("entrez son nouveau Nombre de AD :");
        personnage.Degats = int.Parse(Console.ReadLine());
        Console.Write("entrez son nouveau Nombre de Victime :");
        personnage.NombreVictime = int.Parse(Console.ReadLine());

        context.SaveChanges();
        Console.WriteLine($"  {Pseudo} a été mis à jour avec succès!");
    }
    else
    {
        Console.WriteLine($"{Pseudo} n'a pas été trouvé.");
    }
}

void AfficherTousLesPersonnages()
{
    context.Personnages.ToList().ForEach(l => Console.WriteLine(l.Pseudo));
}



void TaperPersonnage()
{

}




void AfficherPersonnagesSuperieurMoyennePV()
{

}




static void AfficherMenu()
{

    Console.WriteLine("1. Créer un personnage");
    Console.WriteLine("2. Mettre à jour un personnage");
    Console.WriteLine("3. Afficher tous les personnages");
    Console.WriteLine("4. Taper un personnage");
    Console.WriteLine("5. Afficher les personnages ayant des PVs supérieurs à la moyenne");
    Console.WriteLine();
    Console.Write("Choix : ");
}

static void Titre()
{
    Console.WriteLine("  ____                     _   _                  ");
    Console.WriteLine(" |  _ \\ ___ _ __ ___  ___ | \\ | | __ _  __ _  ___ ");
    Console.WriteLine(" | |_) / _ \\ '__/ __|/ _ \\|  \\| |/ _` |/ _` |/ _ \\");
    Console.WriteLine(" |  __/  __/ |  \\__ \\ (_) | |\\  | (_| | (_| |  __/");
    Console.WriteLine(" |_|   \\___|_|  |___/\\___/|_| \\_|\\__,_|\\__, |\\___|");
    Console.WriteLine("                                     |___/      ");
}

Titre();
while (true)
{

    AfficherMenu();


    string choix = Console.ReadLine();

    switch (choix)
    {
        case "1":
            CreerPersonnage();
            break;
        case "2":
            MettreAJourPersonnage();
            break;
        case "3":
            AfficherTousLesPersonnages();
            break;
        case "4":
            TaperPersonnage();
            break;
        case "5":
            AfficherPersonnagesSuperieurMoyennePV();
            break;
        default:
            Console.WriteLine("Choix non valide. Veuillez réessayer.");
            break;
    }
    Console.WriteLine();
    Console.WriteLine();
}
