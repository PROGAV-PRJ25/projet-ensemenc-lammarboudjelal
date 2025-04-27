public class Simulation
{
    private Terrain? terrain1;
    private Terrain? terrain2;
    private Monde? monde;
    private Meteo meteoEnCours = new(0, 0, 0);
    // private ModeDeJeu modeDeJeu = ModeDeJeu.Classique;
    private Dictionary<string, int> recoltes = new Dictionary<string, int>();
    private Dictionary<TypePlante,int> graines = new Dictionary<TypePlante, int>();
    // private int nbActionsRestantes = 8;

    public Simulation()
    {
    }

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

    public static void AttendreUtilisateurPourContinuer()
    {
        Console.WriteLine("Appuyez sur une touche pour continuer...");
        Console.ReadKey();
    }

    public void InitialiserTerrains()
    {
        if (this.monde is not null && this.monde.TypesSolDisponibles is not null)
        {
            this.terrain1 = new Terrain("Terrain 1", this.monde.TypesSolDisponibles.First());
            this.terrain2 = new Terrain("Terrain 2", this.monde.TypesSolDisponibles.Last());
        }
    }

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

    public void Jouer()
    {
        AfficherIntroduction();

        InitialiserMonde();
    }
}