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
        Console.WriteLine("║ 2. Désert Chomp (à venir)        ║");
        Console.WriteLine("║ 3. Jungle Wiggler (à venir)      ║");
        Console.WriteLine("║ 4. Royaume Sorbet (à venir)      ║");
        Console.WriteLine("║ 5. Tropique Lakitu (à venir)     ║");
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
        Console.WriteLine($"{monde.Illustration}");

        Console.WriteLine($"\nVous avez choisi de jouer dans le monde {monde.Nom}.");
        Console.WriteLine("La partie va pouvoir commencer !\n");

        Console.WriteLine("Règles du jeu :\n");
        Console.WriteLine("- Vous disposez de deux terrains de 5x5 cases chacun.");
        Console.WriteLine("- Vous commencez avec 2 graines de chaque type de plante disponible dans votre monde.\n");
        Console.WriteLine("- Chaque semaine, une météo prévisionnelle est générée aléatoirement et influence vos cultures.");
        Console.WriteLine($"- Vous pouvez réaliser jusqu'à {Simulation.NbActionsAutorisees} actions par semaine : arroser, semer, désherber, récolter...");
        Console.WriteLine("- Passez au tour suivant lorsque vous avez terminé vos actions.\n");
        Console.WriteLine("- Conçernant vos plantes, plus les conditions préférées sont réunies, plus elles poussent vite.");
        Console.WriteLine("- En revanche, si les conditions préférées d'une plante ne sont pas respectées à au moins 50%, elle meurt.");
        Console.WriteLine("- De plus, les plantes malades meurent au bout de deux semaines.\n");
        Console.WriteLine("-> Votre objectif est de faire prospérer votre potager au fil des semaines !\n");
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
            Console.Write($"{i+1} ");
            for (int j = 0; j < 5; j++)
            {
                if (terrain1.Plantes?[i,j] is not null)
                    Console.Write($"| {terrain1.Plantes[i,j]!.Symbole} ");
                else
                    Console.Write($"|    ");
            }
            Console.Write("|    ");
            

            for (int j = 0; j < 5; j++)
            {
                if (terrain2.Plantes?[i,j] is not null)
                    Console.Write($"| {terrain2.Plantes[i,j]!.Symbole} ");
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
    public static bool AfficherPlantesTerrain(Terrain terrain)
    {
        Console.WriteLine($"{terrain.Nom} :");
        bool planteTrouvee = false;

        for (int i = 0; i < terrain.Plantes.GetLength(0); i++)
        {
            for (int j = 0; j < terrain.Plantes.GetLength(1); j++)
            {
                if (terrain.Plantes[i, j] is not null)
                {
                    Console.WriteLine($"({i + 1},{j + 1}) {terrain.Plantes[i, j]}");
                    planteTrouvee = true;
                }
            }
        }

        if (!planteTrouvee)
        {
            Console.WriteLine("(Aucune plante plantée pour l'instant)");
        }

        return planteTrouvee;
    }

    /*
        Affiche les informations sur les plantes actuellement semées sur les deux terrains du joueur.

        param terrain1 : Premier terrain du joueur.
        param terrain2 : Deuxième terrain du joueur.
    */
    public static void AfficherPlantes(Terrain terrain1, Terrain terrain2)
    {
        Console.WriteLine("MES PLANTES\n");

        bool plantesT1 = AfficherPlantesTerrain(terrain1);
        Console.WriteLine();
        bool plantesT2 = AfficherPlantesTerrain(terrain2);

        AfficherSeparateur();
    }

    /*
        Affiche l'inventaire actuel de graines du joueur.

        param recoltes : Dictionnaire des récoltes du joueur (type de récolte, quantité).
        param graines : Dictionnaire des semis disponibles pour le joueur (type de plante, quantité).
        param avecCaracteristiques : Permet d'indiquer si on souhaite afficher les caractéristiques des plantes en plus.
    */
    public static void AfficherInventaire(Dictionary<TypePlante, int> recoltes, Dictionary<TypePlante,int> graines, bool avecCaracteristiques = false)
    {
        Console.WriteLine("INVENTAIRE\n");
        
        // Graines
        Console.WriteLine("Graines disponibles :\n");
        int i = 1;
        foreach (var graine in graines)
        {
            Console.WriteLine($"{i} - {graine.Key} : {graine.Value} graine(s) restante(s)");
            if(avecCaracteristiques) Console.WriteLine($"{Plante.AfficherDescription(graine.Key)}\n");
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
}