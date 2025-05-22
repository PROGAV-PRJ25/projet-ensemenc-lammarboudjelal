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
        this.typesPlantesDisponibles.Add(TypePlante.Tomate);
        this.typesPlantesDisponibles.Add(TypePlante.Fraise);
        this.typesPlantesDisponibles.Add(TypePlante.Champignon);
        this.typesPlantesDisponibles.Add(TypePlante.Marguerite);

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
        Liste les caractéristiques : température, météo, plantes et nuisibles spécifiques.
    */
    public override void AfficherDescription()
    {
        Console.Clear();
        
        Console.WriteLine("═════════════════════════════════════════════════════════════════════");
        Console.WriteLine($"MONDE 1 — {this.nom}");
        Console.WriteLine("═════════════════════════════════════════════════════════════════════\n");

        Console.WriteLine($"Bienvenue dans la douce et verdoyante {this.nom} !");
        Console.WriteLine("Ici, tout pousse joyeusement... sauf quand un Goombaver passe par là !\n");

        Console.WriteLine("Caractéristiques du monde :");
        Console.WriteLine("─────────────────────────────────────────────────────────────────────");
        Console.WriteLine("Température idéale : entre 10°C et 25°C (climat tempéré)");
        Console.WriteLine("Météo typique : alternance harmonieuse de pluie et de soleil");
        Console.WriteLine("Plantes cultivables : Tomate 🍅, Fraise 🍓, Marguerite 🌼, Champignon 🍄");
        Console.WriteLine("Nuisibles locaux :");
        Console.WriteLine("   - Goombaver : dévore vos plantes s’il n’est pas repoussé à temps.");
        Console.WriteLine("   - PuceronsKoopa : volent les productions non récoltées.");
        Console.WriteLine("   - Koopascargot : ralentit la croissance de vos plantes.\n");
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
                GererGoombaver(terrain1, terrain2);
                break;
            case 1:
                GererKoopascargot(terrain1, terrain2);
                break;
            case 2:
                GererPuceronKoopa(terrain1, terrain2);
                break;
        }

        Thread.Sleep(2000);
        Console.WriteLine("\nL'urgence est terminée. Retour à la culture !\n");
        Simulation.AttendreUtilisateurPourContinuer();
    }

    /*
        Le PuceronKoopa s'attaque à une plante adulte et détruit sa production.
        Le PuceronKoopa ne sort que s’il y a au moins une plante dont les productions sont récoltables.
        Le joueur dispose de 3 tentatives pour repousser l'intrus, sinon la plante perdra ses productions.

        param terrain1 : Premier terrain du joueur.
        param terrain2 : Deuxième terrain du joueur.
    */
    private static void GererPuceronKoopa(Terrain terrain1, Terrain terrain2)
    {
        GererAttaqueNuisible(
            nomNuisible: "🐞 PuceronKoopa",
            messageIntro: "Une nuée de PuceronsKoopas envahit votre potager !",
            terrain1: terrain1,
            terrain2: terrain2,
            conditionCible: p => p.NbProductionsActuel > 0,
            actionCible: (plante, terrain) =>
            {
                plante.NbProductionsActuel = 0;
                Affichage.AfficherAvertissement($"Les PuceronsKoopas ont détruit les récoltes de la plante {plante.Symbole} en {plante.Coordonnees} !");
            }
        );
    }

    /*
        Le Koopascargot ralentit la croissance de la plante ciblée s’il n’est pas repoussé.
        Le Koopascargot ne sort que s’il y a au moins une plante en bonne santé et non adulte (car ralentir la croissance d'une plante adulte 
        serait un avantage puisqu'elle mourrait moins rapidement), puis cible une plante aléatoirement.
        Le joueur dispose de 3 tentatives pour repousser l'intrus, sinon la plante ciblée aura sa croissance de ralentie de deux semaines.

        param terrain1 : Premier terrain du joueur.
        param terrain2 : Deuxième terrain du joueur.
    */
    private static void GererKoopascargot(Terrain terrain1, Terrain terrain2)
    {
        GererAttaqueNuisible(
            nomNuisible: "🐌 Koopascargot",
            messageIntro: "Un bruit visqueux se rapproche... Un Koopascargot rampe vers votre potager !",
            terrain1: terrain1,
            terrain2: terrain2,
            conditionCible: p => p.Etat == Etat.BonneSante && p.Croissance != Croissance.Adulte,
            actionCible: (plante, terrain) =>
            {
                plante.RetarderCroissance();
                Affichage.AfficherAvertissement($"Le Koopascargot a ralenti la croissance de votre plante {plante.Symbole} en {plante.Coordonnees} !");
            }
        );
    }

    /*
        Gère une attaque de Goombaver sur un des terrains.
        Le Goombaver ne sort que s’il y a au moins une plante vivante, puis cible une plante aléatoirement.
        Le joueur dispose de 3 tentatives pour repousser l'intrus, sinon la plante ciblée est mangée.

        param terrain1 : Premier terrain du joueur.
        param terrain2 : Deuxième terrain du joueur.
    */
    private static void GererGoombaver(Terrain terrain1, Terrain terrain2)
    {
        GererAttaqueNuisible(
            nomNuisible: "🐛 Goombaver",
            messageIntro: "Le sol tremble... Un Goombaver surgit du sous-sol !",
            terrain1: terrain1,
            terrain2: terrain2,
            conditionCible: p => p.Etat != Etat.Morte,
            actionCible: (plante, terrain) =>
            {
                Affichage.AfficherAvertissement($"\nLe Goombaver dévore votre plante {plante.Symbole} en {plante.Coordonnees} !");

                terrain.RetirerPlantesFilles(plante);
                terrain.Emplacements[plante.Coordonnees.X, plante.Coordonnees.Y] = null;
                terrain.Plantes.Remove(plante);
            }
        );
    }
}

