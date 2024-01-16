using System;

class Program
{
    static char[,] tableau = {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };

    static char joueurCourant = 'X';
    static bool partieTerminee = false;

    static void Main()
    {
        while (!partieTerminee)
        {
            AfficherTableau();
            JouerTour();
            VerifierGagnant();
            ChangerJoueur();
        }

        AfficherTableau();
        Console.WriteLine("Partie terminée.");
    }

    static void AfficherTableau()
    {
        Console.Clear();
        Console.WriteLine("Jeu de Morpion");
        Console.WriteLine($"Joueur actuel: {joueurCourant}\n");

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"{tableau[i, j]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void JouerTour()
    {
        Console.Write($"Joueur {joueurCourant}, choisissez une position (1-9) : ");
        string choix = Console.ReadLine();

        if (int.TryParse(choix, out int position) && position >= 1 && position <= 9)
        {
            int ligne = (position - 1) / 3;
            int colonne = (position - 1) % 3;

            if (tableau[ligne, colonne] == 'X' || tableau[ligne, colonne] == 'O')
            {
                Console.WriteLine("Position déjà occupée. Choisissez une autre position.");
                JouerTour();
            }
            else
            {
                tableau[ligne, colonne] = joueurCourant;
            }
        }
        else
        {
            Console.WriteLine("Entrée invalide. Choisissez une position valide (1-9).");
            JouerTour();
        }
    }

    static void VerifierGagnant()
    {
        // Vérification des lignes, colonnes et diagonales
        for (int i = 0; i < 3; i++)
        {
            if (tableau[i, 0] == joueurCourant && tableau[i, 1] == joueurCourant && tableau[i, 2] == joueurCourant ||
                tableau[0, i] == joueurCourant && tableau[1, i] == joueurCourant && tableau[2, i] == joueurCourant)
            {
                AfficherTableau();
                Console.WriteLine($"Le joueur {joueurCourant} a gagné !");
                partieTerminee = true;
                return;
            }
        }

        if (tableau[0, 0] == joueurCourant && tableau[1, 1] == joueurCourant && tableau[2, 2] == joueurCourant ||
            tableau[0, 2] == joueurCourant && tableau[1, 1] == joueurCourant && tableau[2, 0] == joueurCourant)
        {
            AfficherTableau();
            Console.WriteLine($"Le joueur {joueurCourant} a gagné !");
            partieTerminee = true;
            return;
        }

        // Vérification d'égalité
        bool plateauPlein = true;
        foreach (var cellule in tableau)
        {
            if (cellule != 'X' && cellule != 'O')
            {
                plateauPlein = false;
                break;
            }
        }

        if (plateauPlein)
        {
            AfficherTableau();
            Console.WriteLine("Match nul. Aucun joueur n'a gagné.");
            partieTerminee = true;
        }
    }

    static void ChangerJoueur()
    {
        joueurCourant = (joueurCourant == 'X') ? 'O' : 'X';
    }
}
