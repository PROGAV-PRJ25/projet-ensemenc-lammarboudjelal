/*
    Gère la simulation complète du jeu.
    Initialise le monde, les terrains, et permet au joueur d'interagir avec le potager.
*/
public class Simulation
{
    private Terrain? terrain1; // Premier terrain du joueur (5x5 cases).
    private Terrain? terrain2; // Deuxième terrain du joueur (5x5 cases).
    private Monde monde = new PlaineChampignon(); // Monde choisi par le joueur (par défaut Monde 1 - Plaine Champignon).
    private ModeDeJeu modeDeJeu = ModeDeJeu.Classique; // Mode de jeu sélectionné par le joueur.
    private Dictionary<TypePlante, int> recoltes = []; // Dictionnaire des récoltes du joueur (type de récolte, quantité).
    private Dictionary<TypePlante,int> graines = []; // Dictionnaire des semis disponibles pour le joueur (type de plante, quantité).
    private int nbActionsRestantes = 8; // Nombre d'actions que le joueur peut réaliser à chaque tour.

    /*
        Demande au joueur de confirmer une action (O/N).

        return : True si le joueur valide (O), False sinon.
    */
    private static bool DemanderConfirmation()
    {
        Console.WriteLine();
        Console.WriteLine("Voulez-vous valider votre choix ? [O] Oui / [N] Non");

        string reponse = Console.ReadLine() !;
        if (reponse != null && (reponse.Equals("O", StringComparison.CurrentCultureIgnoreCase) || reponse.Equals("OUI", StringComparison.CurrentCultureIgnoreCase)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /*
        Affiche un message pour demander à l'utilisateur d'appuyer sur une touche pour continuer.
    */
    private static void AttendreUtilisateurPourContinuer()
    {
        Console.WriteLine("Appuyez sur une touche pour continuer...");
        Console.ReadKey();
    }

    /*
        Initialise les deux terrains du joueur selon les types de sol du monde choisi.
    */
    private void InitialiserTerrains()
    {
        if (this.monde.TypesSolsDisponibles is not null)
        {
            this.terrain1 = new Terrain("Terrain 1", this.monde.TypesSolsDisponibles.First());
            this.terrain2 = new Terrain("Terrain 2", this.monde.TypesSolsDisponibles.Last());
        }
    }

    /*
        Initialise l'inventaire du joueur.
        Distribut 2 graines de chaque type de plante du monde choisi et initialise les récoltes à 0 par type de plante. 
    */
    private void InitialiserInventaire()
    {
        if (this.monde.TypesPlanteDisponibles is not null)
        {
            foreach (var typePlante in this.monde.TypesPlanteDisponibles)
            {
                this.graines.Add(typePlante, 2);
                this.recoltes.Add(typePlante, 0);
            }
        }
    }

    /*
        Permet au joueur de choisir un monde.
    */
    private void InitialiserMonde()
    {
        bool mondeValide = false;

        while (!mondeValide)
        {
            Console.Clear();

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
            Console.Write("Sélectionnez un monde (1 - 5) : ");

            string choix = Console.ReadLine() !;

            switch (choix)
            {
                case "1":
                    Console.Clear();
                    this.monde.AfficherDescription();
                    mondeValide = DemanderConfirmation();
                    break;
                case "2":
                case "3":
                case "4":
                case "5":
                    Console.WriteLine("Ce monde n'est pas encore disponible. Veuillez en choisir un autre.");
                    AttendreUtilisateurPourContinuer();
                    break;

                default:
                    Console.WriteLine("Choix invalide. Veuillez saisir un chiffre entre 1 et 5.");
                    AttendreUtilisateurPourContinuer();
                    break;
            }
        }
    }

    /*
        Affiche l'introduction stylisée du jeu.
    */
    private static void AfficherIntroduction()
    {
        Console.Clear();
        
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

        AttendreUtilisateurPourContinuer();
    }

    /*
        Affiche une ligne de séparation.
    */
    private static void AfficherSeparateur()
    {
        Console.WriteLine("\n-----------------------------------------------------\n");
        
    }

    /*
    Affiche les deux terrains du joueur sous forme de grilles 5x5 avec des bordures.
    */
    private void AfficherTerrains()
    {
        Console.WriteLine("        Terrain 1                Terrain 2\n");
        Console.WriteLine("    A   B   C   D   E        A   B   C   D   E");

        for (int i = 0; i < 5; i++)
        {
            // Ligne supérieure des cases
            Console.Write("  ");
            for (int j = 0; j < 5; j++)
            {
                Console.Write("+---");
            }
            Console.Write("+   ");

            for (int j = 0; j < 5; j++)
            {
                Console.Write("+---");
            }
            Console.WriteLine("+");

            // Ligne avec numéro + contenu
            Console.Write($"{i+1} ");
            for (int j = 0; j < 5; j++)
            {
                if (terrain1?.Plantes?[i,j] is not null)
                {
                    Console.Write($"| {terrain1?.Plantes[i,j].Symbole} ");
                }
                Console.Write($"|   ");
            }
            Console.Write("|   ");
            

            for (int j = 0; j < 5; j++)
            {
                if (terrain2?.Plantes?[i,j] is not null)
                {
                    Console.Write($"| {terrain2?.Plantes[i,j].Symbole} ");
                }
                Console.Write($"|   ");
            }
            Console.WriteLine("|   ");
        }

        // Dernière ligne horizontale
        Console.Write("  ");
        for (int j = 0; j < 5; j++)
        {
            Console.Write("+---");
        }
        Console.Write("+   ");

        for (int j = 0; j < 5; j++)
        {
            Console.Write("+---");
        }
        Console.WriteLine("+");
    }

    /*
        Affiche les informations sur les plantes actuellement semées.
    */
    private void AfficherPlantes()
    {
        Console.WriteLine("MES PLANTES");
        Console.WriteLine("(Aucune plante plantée pour l'instant)");
        Console.WriteLine();
    }

    /*
        Affiche l'inventaire actuel de graines du joueur.
    */
    private void AfficherInventaire()
    {
        Console.WriteLine("INVENTAIRE");

        foreach (var graine in graines)
        {
            Console.WriteLine($"- {graine.Key} : {graine.Value} graines restantes");
        }

        Console.WriteLine();
    }

    /*
        Affiche le menu des actions et traite le choix du joueur.

        return : False si le joueur choisit de quitter le jeu.
    */
    private bool ChoisirAction()
    {
        Console.WriteLine($"Que faire ? (Actions restantes : {nbActionsRestantes}/8)\n");
        Console.WriteLine("1. Arroser");
        Console.WriteLine("2. Récolter");
        Console.WriteLine("3. Semer");
        Console.WriteLine("4. Désherber");
        Console.WriteLine("5. Passer au tour suivant");
        Console.WriteLine("6. Quitter le jeu\n");

        Console.Write("Entrez le numéro de l'action que vous souhaitez réaliser : ");
        
        string choix = Console.ReadLine()!;

        switch (choix)
        {
            case "1":
                Console.WriteLine("Coming soon...");
                nbActionsRestantes--;
                break;
            case "2":
                Console.WriteLine("Coming soon...");
                nbActionsRestantes--;
                break;
            case "3":
                Console.WriteLine("Coming soon...");
                nbActionsRestantes--;
                break;
            case "4":
                Console.WriteLine("Coming soon...");
                nbActionsRestantes--;
                break;
            case "5":
                Console.WriteLine("Vous passez au tour suivant !");
                nbActionsRestantes = 0;
                break;
            case "6":
                Console.WriteLine("Vous quittez le jeu...");
                return false;

            default:
                Console.WriteLine("Choix invalide.");
                break;
        }

        AttendreUtilisateurPourContinuer();
        Console.Clear();
        return true;
    }

    /*
        Affiche la météo de la semaine passée.
        La météo est sélectionnée aléatoirement parmi les météos possibles dans le monde choisi.
    */
    private void AfficherMeteo()
    {
        Console.WriteLine("MÉTÉO");

        this.monde.DefinirMeteoActuelle();

        Console.WriteLine($"{this.monde.MeteoEnCours}");
    }

    /*
        Gère les tours successifs de la partie.
        Un tour de boucle correspond à une semaine.
    */
    private void LancerBouclePrincipale()
    {
        int semaine = 1;
        bool partieEnCours = true;

        while (partieEnCours)
        {
            this.monde.AfficherIllustration();
            Console.WriteLine($"    --- {this.monde.Nom} - Semaine {semaine} ---");
            AfficherSeparateur();

            this.AfficherMeteo();
            AfficherSeparateur();

            this.AfficherTerrains();
            AfficherSeparateur();

            this.AfficherPlantes();
            AfficherSeparateur();

            this.AfficherInventaire();
            AfficherSeparateur();

            while (nbActionsRestantes > 0 && partieEnCours)
            {
                partieEnCours = this.ChoisirAction();
            }

            if (partieEnCours)
            {
                semaine++;
            }
        }

        Console.WriteLine("Fin de la partie. Merci d'avoir joué à ENSemenC !");
    }

    /*
    Affiche les consignes du jeu avant le lancement d'une partie.
    */
    private void AfficherConsignes()
    {
        this.monde.AfficherIllustration();

        Console.WriteLine($"\nVous avez choisi de jouer dans le monde {this.monde.Nom}.");
        Console.WriteLine("La partie va pouvoir commencer !\n");

        Console.WriteLine("Règles du jeu :");
        Console.WriteLine("- Vous disposez de deux terrains de 5x5 cases chacun.");
        Console.WriteLine("- Vous commencez avec 2 graines de chaque type de plante disponible dans votre monde.");
        Console.WriteLine("- Chaque semaine, une météo est générée aléatoirement et influence vos cultures.");
        Console.WriteLine("- Vous pouvez réaliser jusqu'à 8 actions par semaine : arroser, semer, désherber, récolter...");
        Console.WriteLine("- Passez au tour suivant lorsque vous avez terminé vos actions.");
        Console.WriteLine("- Votre objectif est de faire prospérer votre potager au fil des semaines !\n");

        AttendreUtilisateurPourContinuer();
    }

    /*
        Démarre une partie de jeu.
    */
    public void Jouer()
    {
        AfficherIntroduction();

        // Préparation de la partie : initialisation du monde, des terrains et de l'inventaire du joueur.
        this.InitialiserMonde();
        this.InitialiserTerrains();
        this.InitialiserInventaire();

        Console.Clear();

        // Affichage des consignes.
        this.AfficherConsignes();

        // Lancement du jeu.
        this.LancerBouclePrincipale();
    }
}