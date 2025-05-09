/*
    Représente le monde de la Plaine Champignon, tempéré, adapté aux cultures classiques.
    Hérite de la classe Monde et initialise ses caractéristiques propres.
*/
public class PlaineChampignon : Monde
{
    /*
        Constructeur de la classe Plaine Champignon.
        Initialise le sol, les plantes et les météos typiques du monde.
    */
    public PlaineChampignon(string unNom = "Plaine Champignon") : base(unNom)
    {
        // Sol disponible
        this.typesSolsDisponibles.Add(TypeSol.Humifere);

        // Plantes disponibles
        this.typesPlanteDisponibles.Add(TypePlante.Tomate);
        this.typesPlanteDisponibles.Add(TypePlante.Fraise);
        this.typesPlanteDisponibles.Add(TypePlante.Champignon);
        this.typesPlanteDisponibles.Add(TypePlante.Marguerite);

        // Météos possibles
        this.meteosPossibles.Add(new Meteo(18, 60, 20)); // Météo douce
        this.meteosPossibles.Add(new Meteo(20, 70, 10)); // Journée ensoleillée
        this.meteosPossibles.Add(new Meteo(15, 50, 40)); // Pluie légère
        this.meteosPossibles.Add(new Meteo(22, 80, 5));  // Beau temps
        this.meteosPossibles.Add(new Meteo(12, 30, 60)); // Fortes pluies

        this.meteoPrevisionnelle = this.meteosPossibles[0]; // Par défaut, la météo de départ du monde correspond à la météo la plus simple.

        // Initialisation de l'illustration du monde.
        this.InitialiserIllustration();
    }

    /*
        Affiche une description détaillée du monde Plaine Champignon.
        Liste les caractéristiques : température, météo et plantes disponibles.
    */
    public override void AfficherDescription()
    {
        Console.WriteLine($"Monde 1 — {this.nom}\n");

        Console.WriteLine($"Bienvenue dans {this.nom}, un monde doux et paisible où tout pousse... sauf quand un Goombavers passe par là !\n");

        Console.WriteLine("Caractéristiques :\n");
        Console.WriteLine("   - Température : 10°C à 25°C (tempéré)");
        Console.WriteLine("   - Météo : alternance pluie / soleil");
        Console.WriteLine("   - Plantes : Tomate, Fraise, Marguerite, Champignon\n");
    }

    /*
        Initialiser une illustration ASCII représentant la Plaine Champignon.
    */
    public override void InitialiserIllustration()
    {
        this.Illustration = "                 ⠀⠀⠀⠀⠀⠀⠀⣀⣀⡤⠤⢤⣀⡀\n";
        this.Illustration += "                 ⠀⠀⠀⢀⡤⠚⠉⠑⣀⠔⠐⠢⠀⠈⡹⠶⣄\n";
        this.Illustration += "                 ⠀⠀⡰⠋⠀⠀⠀⠀⡏⢄⣀⡰⢠⠊⠀⠀⠈⠳⡄\n";
        this.Illustration += "                 ⠀⣸⣅⡀⠀⠀⣀⠔⠀⢀⡀⠀⠸⡀⠀⠀⠀⠀⢸⡄\n";
        this.Illustration += "                 ⢀⣿⣿⣾⡭⡭⠐⢢⠊⠁⠈⢣⠀⠙⠢⢄⣠⣴⣿⣷\n";
        this.Illustration += "                 ⢸⠁⠀⠈⠹⣿⣶⣼⣆⣀⣀⣼⣠⣤⣾⣿⠟⠉⠙⢿\n";
        this.Illustration += "                 ⠈⢧⡀⠀⣠⣿⡿⠿⠿⠿⠿⠿⠿⠿⣿⣿⡀⠀⣀⠞\n";
        this.Illustration += "                 ⠀⠀⠈⠉⢩⠃⠀⢀⣤⠀⠀⢠⣦⠀⠀⢸⠉⠉\n";
        this.Illustration += "                 ⠀⠀⠀⠀⢸⠀⠀⠀⠉⡀⠀⢈⠁⠀⠀⢸\n";
        this.Illustration += "                 ⠀⠀⠀⠀⠘⣆⠀⠀⠀⠉⠂⠁⠀⠀⢀⡼\n";
        this.Illustration += "                ⠀⠀⠀⠀⠀⠀⠉⠉⠉⠉⠉⠉⠉⠉⠉\n";
    }

    /*
        Gère une urgence spécifique à la Plaine Champignon : Goombaver, Koopascargot, ou PuceronKoopa.
    */
    public override void LancerUrgence(Terrain terrain1, Terrain terrain2)
    {
        int tirage = new Random().Next(3);

        switch (tirage)
        {
            case 0:
                this.GererGoombaver(terrain1, terrain2);
                break;
            case 1:
                this.GererKoopascargot(terrain1, terrain2);
                break;
            case 2:
                this.GererPuceronKoopa(terrain1, terrain2);
                break;
        }

        Thread.Sleep(2000);
        Console.WriteLine("\nL'urgence est terminée. Retour à la culture !\n");
        Simulation.AttendreUtilisateurPourContinuer();
    }

    /*
        Le PuceronKoopa s'attaque à une plante adulte et détruit sa production.
    */
    private void GererPuceronKoopa(Terrain terrain1, Terrain terrain2)
    {

    }

    /*
        Le Koopascargot se déplace lentement sur une plante et ralentit sa croissance.
    */
    private void GererKoopascargot(Terrain terrain1, Terrain terrain2)
    {

    }

    /*
        Gère une attaque de Goombaver sur un des terrains.
        Le Goombaver ne sort que s’il y a une plante, puis cible une plante aléatoirement.
        Le joueur dispose de 3 tentatives pour repousser l'intrus, sinon la plante ciblée est mangée.
    */
    private void GererGoombaver(Terrain terrain1, Terrain terrain2)
    {
        // Les plantes des terrains 1 et 2 sont rassemblées dans une même liste.
        List<Plante> toutesLesPlantes = [.. terrain1.Plantes, .. terrain2.Plantes];

        // L'intrus n'agit pas si aucune plante n'est plantée.
        if (toutesLesPlantes.Count == 0)
        {
            Console.WriteLine("🐛 Un Goombaver rode... mais ne trouve aucune plante. Il s’enfuit !");
            return;
        }

        // Définition de la plante ciblée par l'intrus.
        Plante cible = toutesLesPlantes[new Random().Next(toutesLesPlantes.Count)];
        Terrain terrainCible = terrain1.Plantes.Contains(cible) ? terrain1 : terrain2;

        // Affichage animé de l'intrus.
        Console.Clear();
        Console.WriteLine("Le sol tremble doucement sous vos pieds...");
        Thread.Sleep(2000);
        Console.WriteLine("Un Goombaver surgit du sous-sol !\n");
        Thread.Sleep(2000);
        Console.WriteLine($"Il fonce vers votre plante {cible.Symbole} en ({cible.X + 1}, {cible.Y + 1}) !");

        int essaisRestants = 3;
        bool repousse = false;

        while (essaisRestants > 0 && !repousse)
        {
            Console.WriteLine($"\nQue faire ? (Actions restantes : {essaisRestants}/8)\n");
            Console.WriteLine("1. Frapper le sol (succès : 70%)");
            Console.WriteLine("2. Vaporiser un jet d'eau (succès : 60%)");
            Console.WriteLine("3. Allumer un répulsif sonore (succès : 80%)");
            Console.WriteLine("4. Ne rien faire\n");

            Console.Write("Entrez le numéro de l'action que vous souhaitez réaliser : ");
            string choix = Console.ReadLine()!;
            double tirage = new Random().NextDouble();

            switch (choix)
            {
                case "1":
                    Console.WriteLine("\n=> Vous frappez le sol avec puissance !");
                    repousse = tirage < 0.7;
                    break;
                case "2":
                    Console.WriteLine("\n=> Vous aspergez la zone d’eau !");
                    repousse = tirage < 0.6;
                    break;
                case "3":
                    Console.WriteLine("\n=> Vous activez un répulsif sonore !");
                    repousse = tirage < 0.8;
                    break;
                default:
                    Console.WriteLine("\n=> Vous ne faites rien...Original comme choix...");
                    essaisRestants = 0;
                    break;
            }

            essaisRestants--;

            if (repousse)
            {
                Console.WriteLine("\nLe Goombaver est effrayé et détale sous terre !");
                return;
            }

            if (essaisRestants > 0 && !repousse)
                Console.WriteLine("\nLe Goombaver hésite mais reste menaçant...");
        }

        // Le joueur n'est pas parvenu à se débarraser de l'intrus : la plante est perdue.
        Console.WriteLine($"\nÉchec ! Le Goombaver a dévoré votre {cible.Symbole} en ({cible.X + 1}, {cible.Y + 1}) !");
        terrainCible.Emplacements[cible.X, cible.Y] = null;
        terrainCible.Plantes.Remove(cible);
    }
}

