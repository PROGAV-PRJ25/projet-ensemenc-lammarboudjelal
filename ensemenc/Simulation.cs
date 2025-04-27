/*
    Gère la simulation complète du jeu.
    Initialise le monde, les terrains, et permet au joueur d'interagir avec le potager.
*/
public class Simulation
{
    private Terrain? terrain1; // Premier terrain du joueur (5x5 cases).
    private Terrain? terrain2; // Deuxième terrain du joueur (5x5 cases).
    private Monde? monde; // Monde choisi par le joueur.
    private Meteo meteoEnCours = new(0, 0, 0); // Météo actuelle dans le monde.
    // private ModeDeJeu modeDeJeu = ModeDeJeu.Classique; // Mode de jeu sélectionné par le joueur.
    private Dictionary<TypePlante, int> recoltes = new Dictionary<TypePlante, int>(); // Dictionnaire des récoltes du joueur (type de récolte, quantité).
    private Dictionary<TypePlante,int> graines = new Dictionary<TypePlante, int>(); // Dictionnaire des semis disponibles pour le joueur (type de plante, quantité).
    // private int nbActionsRestantes = 8; // Nombre d'actions que le joueur peut réaliser à chaque tour.

    /*
        Demande au joueur de confirmer une action (O/N).

        return : True si le joueur valide (O), False sinon.
    */
    public static bool DemanderConfirmation()
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
    public static void AttendreUtilisateurPourContinuer()
    {
        Console.WriteLine("Appuyez sur une touche pour continuer...");
        Console.ReadKey();
    }

    /*
        Initialise les deux terrains du joueur selon les types de sol du monde choisi.
    */
    public void InitialiserTerrains()
    {
        if (this.monde is not null && this.monde.TypesSolsDisponibles is not null)
        {
            this.terrain1 = new Terrain("Terrain 1", this.monde.TypesSolsDisponibles.First());
            this.terrain2 = new Terrain("Terrain 2", this.monde.TypesSolsDisponibles.Last());
        }
    }

    /*
        Permet au joueur de choisir un monde, valide son choix et initialise ses terrains.
    */
    public void InitialiserMonde()
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
                    this.monde = new PlaineChampignon();
                    this.InitialiserTerrains();
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
    public static void AfficherIntroduction()
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
        Démarre une partie de jeu.
    */
    public void Jouer()
    {
        AfficherIntroduction();
        InitialiserMonde();
    }
}