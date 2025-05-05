/*
    Gère la simulation complète du jeu.
    Initialise le monde, les terrains, et permet au joueur d'interagir avec le potager.
*/
public class Simulation
{
    private Terrain terrain1 = new("Terrain 1"); // Premier terrain du joueur (5x5 cases).
    private Terrain terrain2 = new("Terrain 2"); // Deuxième terrain du joueur (5x5 cases).
    private Monde monde = new PlaineChampignon(); // Monde choisi par le joueur (par défaut Monde 1 - Plaine Champignon).
    // private ModeDeJeu modeDeJeu = ModeDeJeu.Classique; // Mode de jeu sélectionné par le joueur.
    private Dictionary<TypePlante, int> recoltes = []; // Dictionnaire des récoltes du joueur (type de récolte, quantité).
    private Dictionary<TypePlante,int> graines = []; // Dictionnaire des semis disponibles pour le joueur (type de plante, quantité).
    private const int NbActionsAutorisees = 8; // Nombre d'actions que le joueur peut réaliser à chaque tour.
    private int nbActionsRestantes = NbActionsAutorisees; // Nombre d'actions restants au joueur (réinitialisé chaque semaine).

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
        this.terrain1.TypeSol = this.monde.TypesSolsDisponibles.First();
        this.terrain2.TypeSol = this.monde.TypesSolsDisponibles.Last();
    }

    /*
        Initialise l'inventaire du joueur.
        Distribut 2 graines de chaque type de plante du monde choisi et initialise les récoltes à 0 par type de plante. 
    */
    private void InitialiserInventaire()
    {
        foreach (var typePlante in this.monde.TypesPlanteDisponibles)
        {
            this.graines.Add(typePlante, 2);
            this.recoltes.Add(typePlante, 0);
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
        Console.WriteLine("\n----------------------------------------------------------\n");
        
    }

    /*
    Affiche les deux terrains du joueur sous forme de grilles 5x5 avec des bordures.
    */
    private void AfficherTerrains()
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
    }

    /*
        Affiche les plantes présentes sur un terrain donné, avec leurs coordonnées et leur représentation.

        param terrain : Le terrain à analyser.

        return : True si au moins une plante est présente, False sinon.
    */
    private bool AfficherPlantesTerrain(Terrain terrain)
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
    */
    private void AfficherPlantes()
    {
        Console.WriteLine("MES PLANTES\n");

        bool plantesT1 = AfficherPlantesTerrain(this.terrain1);
        Console.WriteLine();
        bool plantesT2 = AfficherPlantesTerrain(this.terrain2);

        Console.WriteLine();
    }

    /*
        Affiche l'inventaire actuel de graines du joueur.

        param avecCaracteristiques : Permet d'indiquer si on souhaite afficher les caractéristiques des plantes en plus.
    */
    private void AfficherInventaire(bool avecCaracteristiques = false)
    {
        Console.WriteLine("INVENTAIRE\n");
        
        int i = 1;
        foreach (var graine in graines)
        {
            Console.WriteLine($"{i} - {graine.Key} : {graine.Value} graines restantes");
            if(avecCaracteristiques) Console.WriteLine($"{Plante.AfficherDescription(graine.Key)}\n");
            i++;
        }
    }

    /*
        Demande à l'utilisateur de choisir entre son terrain 1 et 2.

        return : Le terrain sélectionné. 
    */
    private Terrain ChoisirTerrain()
    {
        while (true)
        {
            Console.WriteLine("\nSur quel terrain souhaitez-vous agir ?");
            Console.WriteLine("1. Terrain 1");
            Console.WriteLine("2. Terrain 2");

            Console.Write("Entrez votre choix : ");
            string saisie = Console.ReadLine() !;

            if (saisie == "1")
                return this.terrain1;

            if (saisie == "2")
                return this.terrain2;

            Console.WriteLine("Choix invalide. Veuillez réessayer.");
        }
    }

    /*
        Demande un entier à l'utilisateur dans une plage définie.
     
        param message : Message affiché à l'utilisateur.
        param min : Valeur minimale autorisée.
        param max : Valeur maximale autorisée.

        return : Un entier valide dans l’intervalle.
    */
    public static int SaisirEntier(string message, int min, int max)
    {
        int valeur = min - 1;
        while (valeur < min || valeur > max)
        {
            Console.Write(message + $" ({min} - {max}) : ");
            int.TryParse(Console.ReadLine()!, out valeur);

            if (valeur < min || valeur > max)
            {
                Console.WriteLine($"Choix invalide. Veuillez saisir un chiffre entre {min} et {max}.");
                AttendreUtilisateurPourContinuer();
                Console.WriteLine();
            }
        }

        return valeur;
    }

    /*
        Demande à l'utilisateur de choisir parmi les semis qu'il possède.

        return : Type de plante correspondant au semis choisi.
    */
    private TypePlante ChoisirSemis()
    {
        AfficherInventaire(true);

        bool choixValide = false;
        int choix;
        TypePlante typeChoisi = default;

        while (! choixValide)
        {
            choix = SaisirEntier("Choisissez un type de plante à semer ", 1, this.graines.Count); 
            typeChoisi = this.graines.Keys.ElementAt(choix - 1); 

            if (this.graines[typeChoisi] == 0)
                Console.WriteLine("Vous n'avez plus de graines de ce type. Veuillez en choisir une autre.");
            else
                choixValide = true;
        }

        this.graines[typeChoisi] -= 1;
        return typeChoisi;
    }

    /*
        Permet au joueur de semer une plante sur un terrain.
        Le joueur choisi le type de plante, un terrain, des coordonnées valides, 
        et la graine est plantée si l'emplacement est libre.
    */
    private void Semer()
    {
        Console.WriteLine("\n=> Semer\n");

        // Si le joueur n'a plus de graines dans son inventaire, il ne peut rien semer.
        int totalGraines = 0;
        foreach (var graine in this.graines)
        {
            totalGraines += graine.Value;
        }
        if (totalGraines == 0)
        {
            Console.WriteLine("Vous n'avez plus de graines dans votre inventaire.");
            return;
        }

        // Choix de la plante à semer.
        TypePlante typeChoisi = this.ChoisirSemis();

        // Semence.
        bool plantee = this.ChoisirTerrain().Semer(typeChoisi);
        if (plantee)
            Console.WriteLine("Graine plantée avec succès !");
        else
            Console.WriteLine("La graine n’a pas pu être plantée.");
    }

    /*
        Permet au joueur de retirer une plante sur un terrain choisi.
    */
    private void Desherber()
    {
        bool planteRetiree = this.ChoisirTerrain().Desherber();
        if(planteRetiree)
            Console.WriteLine("Plante retirée avec succès !");
    }

    /*
        Permet au joueur d'arroser une plante sur un terrain choisi.
    */
    private void Arroser()
    {
        bool planteArrosee = this.ChoisirTerrain().Arroser();
        if(planteArrosee)
            Console.WriteLine("Votre plante est désaltérée !");
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
                this.Arroser();
                nbActionsRestantes--;
                break;
            case "2":
                Console.WriteLine("Coming soon...");
                nbActionsRestantes--;
                break;
            case "3":
                this.Semer();
                nbActionsRestantes--;
                break;
            case "4":
                this.Desherber();
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
        return true;
    }

    /*
        Affiche la météo prévisionnelle de la semaine à venir.
        La météo est sélectionnée aléatoirement parmi les météos possibles dans le monde choisi.
    */
    private void AfficherMeteo()
    {
        Console.WriteLine("MÉTÉO PRÉVISIONNELLE DE LE SEMAINE À VENIR\n");

        this.monde.DefinirMeteoPrevisionnelle();

        Console.WriteLine($"{this.monde.MeteoPrevisionnelle}");
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
            if (semaine != 1)
                Console.WriteLine($"Une semaine vient de s'écouler...\nEspérons que vos plantes vont bien...");
            Console.WriteLine($"C'est parti pour la semaine {semaine} !");

            AttendreUtilisateurPourContinuer();
            Console.Clear();

            while (nbActionsRestantes > 0 && partieEnCours)
            {
                this.monde.AfficherIllustration();
                Console.WriteLine($"          --- {this.monde.Nom} - Semaine {semaine} ---");
                AfficherSeparateur();

                this.AfficherMeteo();
                AfficherSeparateur();

                this.AfficherTerrains();
                AfficherSeparateur();

                this.AfficherPlantes();
                AfficherSeparateur();

                this.AfficherInventaire();
                AfficherSeparateur();

                partieEnCours = this.ChoisirAction();

                Console.Clear();
            }

            if (partieEnCours)
            {
                semaine++;
                nbActionsRestantes = NbActionsAutorisees;
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
        Console.WriteLine($"- Vous pouvez réaliser jusqu'à {NbActionsAutorisees} actions par semaine : arroser, semer, désherber, récolter...");
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

        Console.Clear();

        // Lancement du jeu.
        this.LancerBouclePrincipale();
    }
}