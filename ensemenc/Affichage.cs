/*
    Centralise toutes les fonctions d'affichage et de style du jeu.
*/
public class Affichage()
{
    /*
        Affiche le menu des mondes.
    */
    public static void AfficherMenuMondes()
    {
        Console.WriteLine("╔══════════════════════════════════╗");
        Console.WriteLine("║           CHOIX DU MONDE         ║");
        Console.WriteLine("╠══════════════════════════════════╣");
        Console.WriteLine("║ 1. Plaine Champignon             ║");
        Console.WriteLine("║ 2. Désert Chomp                  ║");
        Console.WriteLine("╚══════════════════════════════════╝");
        Console.WriteLine();
    }

    /*
        Affiche l'introduction stylisée du jeu.
    */
    public static void AfficherIntroduction()
    {
        Console.WriteLine("        __           ");
        Console.WriteLine("     .-'  |          ");
        Console.WriteLine("    /   <\\|         ");
        Console.WriteLine("   /     \'          ");
        Console.WriteLine("   |_.- o-o          ");
        Console.WriteLine("   / C  -._)\\       ");
        Console.WriteLine("  /',        |        _____ _   _  _____                           _____ ");
        Console.WriteLine(" |   `-,_,__,'       |  ___| \\ | |/  ___|                         /  __ \\");
        Console.WriteLine(" (,,)====[_]=|       | |__ |  \\| |\\ `--.  ___ _ __ ___   ___ _ __ | /  \\/");
        Console.WriteLine("   '.   ____/        |  __|| . ` | `--. \\/ _ \\ '_ ` _ \\ / _ \\ '_ \\| |    ");
        Console.WriteLine("    | -|-|_          | |___| |\\  |/\\__/ /  __/ | | | | |  __/ | | | \\__/\\");
        Console.WriteLine("    |____)_)         \\____/\\_| \\_/\\____/ \\___|_| |_| |_|\\___|_| |_|\\____/\n\n");

        Console.WriteLine("Bienvenue dans ENSemenC, un jeu de simulateur de potager !\n");
    }

    /*
        Affiche une ligne de séparation.
    */
    public static void AfficherSeparateur()
    {
        Console.WriteLine();
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine();
    }

    /*
        Affiche les consignes du jeu avant le lancement d'une partie.

        param monde : Monde dans lequel la partie va se dérouler.
    */
    public static void AfficherConsignes(Monde monde)
    {
        Console.Clear();
        Console.WriteLine($"{monde.Illustration}\n");

        Console.WriteLine("═════════════════════════════════════════════════════════════════════");
        Console.WriteLine($"Bienvenue dans le monde de {monde.Nom} !");
        Console.WriteLine("═════════════════════════════════════════════════════════════════════\n");

        Console.WriteLine("RÈGLES DU JEU");
        Console.WriteLine("─────────────────────────────────────────────────────────────────────");

        Console.WriteLine("Potager & Ressources :");
        Console.WriteLine($"- Vous disposez de deux terrains de 5x5 cases chacun.");
        Console.WriteLine("- Vous débutez avec 2 graines de chaque plante disponible dans le monde choisi.\n");

        Console.WriteLine("Météo & Saisons :");
        Console.WriteLine("- Chaque semaine, une météo prévisionnelle influence vos plantes.");
        Console.WriteLine("- Température, ensoleillement et pluie jouent un rôle crucial.\n");

        Console.WriteLine("Actions disponibles :");
        Console.WriteLine($"- Vous pouvez effectuer jusqu’à {Simulation.NbActionsAutorisees} actions par semaine.");
        Console.WriteLine("- Actions possibles : arroser, semer, désherber, récolter...");
        Console.WriteLine("- Vous pouvez passer au tour suivant une fois vos actions terminées.\n");

        Console.WriteLine("Croissance des plantes :");
        Console.WriteLine("- Des conditions optimales (eau, soleil, sol) accélèrent leur croissance.");
        Console.WriteLine("- Si l’arrosage ou la température s’éloigne trop de leurs besoins : elles meurent !");
        Console.WriteLine("- Une plante malade pendant 2 semaines consécutives meurt également.\n");

        Console.WriteLine("Mode Urgence :");
        Console.WriteLine("- Chaque semaine, il y a 60% de chances qu'une urgence survienne !");
        Console.WriteLine("- Vous devrez réagir à un nuisible spécifique à votre monde.");
        Console.WriteLine("- Vous avez 3 actions pour éviter ses dégâts !\n");

        Console.WriteLine("Objectif :");
        Console.WriteLine("-> Faites prospérer votre potager et protégez vos plantations !\n");

        Console.WriteLine("═════════════════════════════════════════════════════════════════════\n");
    }

    /*
        Affiche la météo prévisionnelle de la semaine à venir.

        param meteo : Météo prévisionnelle à afficher.
    */
    public static void AfficherMeteoPrevisionnelle(Meteo meteo)
    {
        Console.WriteLine("MÉTÉO PRÉVISIONNELLE DE LE SEMAINE À VENIR\n");

        Console.WriteLine($"{meteo}");

        AfficherSeparateur();
    }

    /*
        Affiche l'en-tête lors d'un tour de jeu contenant l'illustration et le nom du monde, ainsi que le numéro de la semaine.

        param monde : Monde joué.
        param semaine : Numéro de la semaine (correspond au nombre de tour de jeu).
    */
    public static void AfficherMondeEtSemaine(Monde monde, int semaine)
    {
        Console.WriteLine($"{monde.Illustration}");
        Console.WriteLine($"          --- {monde.Nom} - Semaine {semaine} ---");

        AfficherSeparateur();
    }

    /*
        Affiche les deux terrains du joueur sous forme de grilles 5x5 avec des bordures.

        param terrain1 : Premier terrain du joueur.
        param terrain2 : Deuxième terrain du joueur.
    */
    public static void AfficherTerrains(Terrain terrain1, Terrain terrain2)
    {
        Console.WriteLine("          Terrain 1                     Terrain 2\n");
        Console.WriteLine("    1    2    3    4    5         1    2    3    4    5");

        for (int i = 0; i < 5; i++)
        {
            // Ligne supérieure des cases
            Console.Write("  ");
            for (int j = 0; j < 5; j++)
            {
                Console.Write("+----");
            }
            Console.Write("+    ");

            for (int j = 0; j < 5; j++)
            {
                Console.Write("+----");
            }
            Console.WriteLine("+");

            // Ligne avec numéro + contenu
            Console.Write($"{i + 1} ");
            for (int j = 0; j < 5; j++)
            {
                if (terrain1.Emplacements?[i, j] is not null)
                    Console.Write($"| {terrain1.Emplacements[i, j]!.Symbole} ");
                else
                    Console.Write($"|    ");
            }
            Console.Write("|    ");


            for (int j = 0; j < 5; j++)
            {
                if (terrain2.Emplacements?[i, j] is not null)
                    Console.Write($"| {terrain2.Emplacements[i, j]!.Symbole} ");
                else
                    Console.Write($"|    ");
            }
            Console.WriteLine("|");
        }

        // Dernière ligne horizontale
        Console.Write("  ");
        for (int k = 0; k < 2; k++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write("+----");
            }
            Console.Write("+    ");
        }
        Console.WriteLine();

        AfficherSeparateur();
    }

    /*
        Affiche les plantes présentes sur un terrain donné, avec leurs coordonnées et leur représentation.

        param terrain : Le terrain à analyser.

        return : True si au moins une plante est présente, False sinon.
    */
    public static void AfficherPlantesTerrain(Terrain terrain)
    {
        Console.WriteLine($"{terrain.Nom} :");
        bool planteTrouvee = terrain.Plantes.Count != 0;

        if (!planteTrouvee)
            Console.WriteLine("(Aucune plante plantée pour l'instant)");
        else
        {
            foreach (var plante in terrain.Plantes)
            {
                Console.WriteLine($"{plante.Coordonnees} {plante}");
            }
        }
    }

    /*
        Affiche les informations sur les plantes actuellement semées sur les deux terrains du joueur.

        param terrain1 : Premier terrain du joueur.
        param terrain2 : Deuxième terrain du joueur.
    */
    public static void AfficherPlantes(Terrain terrain1, Terrain terrain2)
    {
        Console.WriteLine("MES PLANTES\n");

        AfficherPlantesTerrain(terrain1);
        Console.WriteLine();
        AfficherPlantesTerrain(terrain2);

        AfficherSeparateur();
    }

    /*
        Affiche l'inventaire actuel de graines du joueur.

        param recoltes : Dictionnaire des récoltes du joueur (type de récolte, quantité).
        param graines : Dictionnaire des semis disponibles pour le joueur (type de plante, quantité).
        param avecCaracteristiques : Permet d'indiquer si on souhaite afficher les caractéristiques des plantes en plus.
    */
    public static void AfficherInventaire(Dictionary<TypePlante, int> recoltes, Dictionary<TypePlante, int> graines, bool avecCaracteristiques = false)
    {
        Console.WriteLine("INVENTAIRE\n");

        // Graines
        Console.WriteLine("Graines disponibles :\n");
        int i = 1;
        foreach (var graine in graines)
        {
            Console.WriteLine($"{i} - {graine.Key} : {graine.Value} graine(s) restante(s)");
            if (avecCaracteristiques) Console.WriteLine($"{Plante.AfficherDescription(graine.Key)}\n");
            i++;
        }

        // Récoltes
        if (recoltes.Any(kv => kv.Value > 0) && !avecCaracteristiques)
        {
            Console.WriteLine("\nRécoltes en stock :\n");
            foreach (var recolte in recoltes)
            {
                if (recolte.Value > 0)
                    Console.WriteLine($"- {recolte.Key} : {recolte.Value} unité(s) récoltée(s)");
            }
        }
    }

    /*
        Affiche le menu des actions que le joueur peut réaliser.
    */
    public static void AfficherMenuActions()
    {
        Console.WriteLine("1. Arroser");
        Console.WriteLine("2. Récolter");
        Console.WriteLine("3. Semer");
        Console.WriteLine("4. Désherber");
        Console.WriteLine("5. Soigner");
        Console.WriteLine("6. Passer au tour suivant");
        Console.WriteLine("7. Quitter le jeu\n");
    }

    /*
        Affiche un message en couleur, puis rétablit la couleur par défaut.

        param message : Le texte à afficher.
        param couleur : La couleur à utiliser.
    */
    private static void AfficherMessageColore(string message, ConsoleColor couleur)
    {
        Console.ForegroundColor = couleur;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    /*
        Affiche un message d'erreur en rouge.
        
        param message : Le texte d'erreur à afficher.
    */
    public static void AfficherErreur(string message)
    {
        AfficherMessageColore(message, ConsoleColor.Red);
    }

    /*
        Affiche un message de confirmation en vert.

        param message : Le texte d'erreur à afficher.
    */
    public static void AfficherSucces(string message)
    {
        AfficherMessageColore(message, ConsoleColor.Green);
    }

    /*
        Affiche un message d'avertissement en jaune.
        Un message d'avertissement peut également être un message à connotation négative comme l'annonce de la mort d'une plante.

        param message : Le texte d'erreur à afficher.
    */
    public static void AfficherAvertissement(string message)
    {
        AfficherMessageColore(message, ConsoleColor.DarkYellow);
    }

    /*
        Affiche un message d'interaction avec l'utilisateur en cyan (par exemple : saisie attendue).

        param message : Le texte à afficher.
    */
    public static void AfficherSaisieUtilisateur(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write(message);
        Console.ResetColor();
    }
}