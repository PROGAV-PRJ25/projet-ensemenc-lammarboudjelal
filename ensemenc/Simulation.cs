/*
    Gère la simulation complète du jeu.
    Initialise le monde, les terrains, et permet au joueur d'interagir avec le potager.
*/
public class Simulation
{
    private Terrain terrain1 = new("Terrain 1"); // Premier terrain du joueur (5x5 cases).
    private Terrain terrain2 = new("Terrain 2"); // Deuxième terrain du joueur (5x5 cases).
    private Monde monde = new PlaineChampignon(); // Monde choisi par le joueur (par défaut Monde 1 - Plaine Champignon).
    private Dictionary<TypePlante, int> recoltes = []; // Dictionnaire des récoltes du joueur (type de récolte, quantité).
    private Dictionary<TypePlante,int> graines = []; // Dictionnaire des semis disponibles pour le joueur (type de plante, quantité).
    public const int NbActionsAutorisees = 8; // Nombre d'actions que le joueur peut réaliser à chaque tour.
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
    public static void AttendreUtilisateurPourContinuer()
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

            Affichage.AfficherMenuMondes();

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
            Console.WriteLine();

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
    private static int SaisirEntier(string message, int min, int max)
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
        Demande les coordonnées à l'utilisateur et retourne (x, y).
    
        return : Tuple (x, y) si l'utilisateur entre des valeurs valides.
    */
    private static (int x, int y) SaisirCoordonnees(string action)
    {
        Console.WriteLine($"Coordonnées de la plante à {action} :");
        int x = SaisirEntier("Ligne ", 1, 5) - 1; // -1 car un tableau commence à l'indice 0.
        int y = SaisirEntier("Colonne ", 1, 5) - 1;
        Console.WriteLine();
        return (x, y);
    }

    /*
        Permet au joueur d'arroser une plante sur un terrain choisi.
    */
    private void Arroser()
    {
        Console.WriteLine("\n=> Arroser");

        Terrain terrainChoisi = this.ChoisirTerrain();

        var (x, y) = SaisirCoordonnees("arroser");

        bool planteArrosee = terrainChoisi.Arroser(x, y);

        if(planteArrosee)
            Console.WriteLine("Votre plante est désaltérée !");
        else
            Console.WriteLine("Aucune plante n'est positionnée à ces coordonnées. C'est dommage, vous venez de perdre une action...");
    }

    /*
        Permet au joueur de récolter les productions d'une plante.
    */
    private void Recolter()
    {
        Console.WriteLine("\n=> Récolter");

        Terrain terrainChoisi = this.ChoisirTerrain();

        var (x, y) = SaisirCoordonnees("récolter");

        var (plantePresente, type, quantite) = terrainChoisi.Recolter(x, y);

        if (! plantePresente)
            Console.WriteLine("Aucune plante n'est positionnée à ces coordonnées. C'est dommage, vous venez de perdre une action...");
        else if (quantite == 0)
            Console.WriteLine("Cette plante n’a rien produit cette semaine. Il faudra patienter...");
        else
        {
            if (type != null)
            {
                if (this.recoltes.ContainsKey(type.Value))
                    this.recoltes[type.Value] += quantite;
                else
                    this.recoltes[type.Value] = quantite;

                Console.WriteLine($"Vous avez récolté {quantite} unité(s) de {type} !");
            }
        }
    }

    /*
        Demande à l'utilisateur de choisir parmi les semis qu'il possède.

        return : Type de plante correspondant au semis choisi.
    */
    private TypePlante ChoisirSemis()
    {
        Affichage.AfficherInventaire(this.recoltes, this.graines, true);

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

        // Choix du terrain sur lequel mettre le semis.
        Terrain terrainChoisi = this.ChoisirTerrain();

        // Choix des coordonnées de semis.
        var (x,y) = SaisirCoordonnees("semer");

        // Semence.
        bool plantee = terrainChoisi.Semer(typeChoisi, x, y);
        if (plantee)
            Console.WriteLine("Graine plantée avec succès !");
        else
            Console.WriteLine($"L'emplacement est déjà occupé par une autre plante. C'est dommage, vous venez de perdre une graine...");
    }

    /*
        Permet au joueur de retirer une plante sur un terrain choisi.
    */
    private void Desherber()
    {
        Console.WriteLine("\n=> Désherber");

        Terrain terrainChoisi = this.ChoisirTerrain();

        var (x, y) = SaisirCoordonnees("retirer");

        bool planteRetiree = terrainChoisi.Desherber(x, y);
        if(planteRetiree)
            Console.WriteLine("Plante retirée avec succès !");
        else 
            Console.WriteLine("Aucune plante n'est positionnée à ces coordonnées. C'est dommage, vous venez de perdre une action...");
    }

    /*
        Permet au joueur de soigner une plante.
    */
    private void Soigner()
    {
        Console.WriteLine("\n=> Soigner");

        Terrain terrainChoisi = this.ChoisirTerrain();

        var (x, y) = SaisirCoordonnees("soigner");

        terrainChoisi.Traiter(x, y);
    }

    /*
        Affiche le menu des actions et traite le choix du joueur.

        return : False si le joueur choisit de quitter le jeu.
    */
    private bool ChoisirAction()
    {
        Console.WriteLine($"Que faire ? (Actions restantes : {nbActionsRestantes}/8)\n");
        Affichage.AfficherMenuActions();
        
        Console.Write("Entrez le numéro de l'action que vous souhaitez réaliser : ");
        string choix = Console.ReadLine()!;

        switch (choix)
        {
            case "1":
                this.Arroser();
                nbActionsRestantes--;
                break;
            case "2":
                this.Recolter();
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
                this.Soigner();
                nbActionsRestantes--;
                break;
            case "6":
                Console.WriteLine("Vous passez au tour suivant !");
                nbActionsRestantes = 0;
                break;
            case "7":
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
        Lance un événement d'urgence dans le jeu (mode urgence).
        Le joueur doit agir rapidement contre un nuisible spécifique.
    */
    private void LancerModeUrgence()
    {
        Console.Clear();
        Console.WriteLine("⚠️ URGENCE : Quelque chose menace votre potager !\n");
        Thread.Sleep(2000);

        this.monde.LancerUrgence(this.terrain1, this.terrain2);
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
            Console.Clear();

            if (semaine != 1)
                Console.WriteLine($"Une semaine vient de s'écouler...\nEspérons que vos plantes vont bien...");
            Console.WriteLine($"C'est parti pour la semaine {semaine} !");

            AttendreUtilisateurPourContinuer();
            Console.Clear();

            // La météo prévisionnelle est sélectionnée aléatoirement parmi les météos possibles dans le monde choisi.
            this.monde.DefinirMeteoPrevisionnelle();

            while (nbActionsRestantes > 0 && partieEnCours)
            {
                Affichage.AfficherMondeEtSemaine(this.monde, semaine);

                Affichage.AfficherMeteoPrevisionnelle(this.monde.MeteoPrevisionnelle);

                Affichage.AfficherTerrains(this.terrain1, this.terrain2);

                Affichage.AfficherPlantes(this.terrain1, this.terrain2);

                Affichage.AfficherInventaire(this.recoltes, this.graines);
                Affichage.AfficherSeparateur();

                partieEnCours = this.ChoisirAction();

                Console.Clear();
            }

            // Déclenchement du mode urgence : 60% de chance de déclencher un évènement
            if (partieEnCours)
            {
                bool urgence = Random.Shared.NextDouble() < 0.6;
                if (urgence)
                    this.LancerModeUrgence();
            }

            // Mise à jour des plantes en fin de tour
            this.terrain1.MettreAJourPlantes(this.monde.MeteoPrevisionnelle);
            this.terrain2.MettreAJourPlantes(this.monde.MeteoPrevisionnelle);

            if (partieEnCours)
            {
                semaine++;
                nbActionsRestantes = NbActionsAutorisees;
            }
        }

        Console.WriteLine("Fin de la partie. Merci d'avoir joué à ENSemenC !");
    }

    /*
        Démarre une partie de jeu.
    */
    public void Jouer()
    {
        Console.Clear();

        Affichage.AfficherIntroduction();
        AttendreUtilisateurPourContinuer();

        // Préparation de la partie : initialisation du monde, des terrains et de l'inventaire du joueur.
        this.InitialiserMonde();
        this.InitialiserTerrains();
        this.InitialiserInventaire();

        Console.Clear();

        // Affichage des consignes.
        Affichage.AfficherConsignes(this.monde);
        AttendreUtilisateurPourContinuer();

        Console.Clear();

        // Lancement du jeu.
        this.LancerBouclePrincipale();
    }
}