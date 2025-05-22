/*
    Représente le monde du Désert Chomp, aride et impitoyable.
    Hérite de la classe Monde et initialise ses caractéristiques propres.
*/
public class DesertChomp : Monde
{
    /*
        Constructeur du monde Désert Chomp.
        Initialise les types de sol, plantes disponibles et météos typiques.
    */
    public DesertChomp(string unNom = "Désert Chomp") : base(unNom)
    {
        // Sol disponible
        this.typesSolsDisponibles.Add(TypeSol.Sableux);

        // Plantes disponibles dans ce monde aride
        this.typesPlantesDisponibles.Add(TypePlante.Cactus);
        this.typesPlantesDisponibles.Add(TypePlante.AloeVera);
        this.typesPlantesDisponibles.Add(TypePlante.PlanteFeu);
        this.typesPlantesDisponibles.Add(TypePlante.Dattier);

        // Météos typiques du désert
        this.meteosPossibles.Add(new Meteo(38, 95, 5));   // Canicule
        this.meteosPossibles.Add(new Meteo(40, 100, 0));  // Que calor
        this.meteosPossibles.Add(new Meteo(32, 80, 10));  // Chaleur sèche
        this.meteosPossibles.Add(new Meteo(35, 90, 15));  // Vent chaud
        this.meteosPossibles.Add(new Meteo(30, 50, 30));  // Tempête de sable

        this.meteoPrevisionnelle = this.meteosPossibles[0];

        this.InitialiserIllustration();
    }

    /*
        Affiche une description détaillée du monde Désert Chomp.
    */
    public override void AfficherDescription()
    {
        Console.Clear();

        Console.WriteLine("═════════════════════════════════════════════════════════════════════");
        Console.WriteLine($"MONDE 2 — {this.nom}");
        Console.WriteLine("═════════════════════════════════════════════════════════════════════\n");

        Console.WriteLine($"Bienvenue dans le brûlant {this.nom} !");
        Console.WriteLine("Seules les plantes les plus résistantes survivent aux crocs du sable...\n");

        Console.WriteLine("Caractéristiques du monde :");
        Console.WriteLine("─────────────────────────────────────────────────────────────────────");
        Console.WriteLine("Température : entre 30°C et 45°C (chaleur extrême)");
        Console.WriteLine("Météo : temps sec, rares pluies, tempêtes de sable occasionnelles");
        Console.WriteLine("Plantes cultivables : Cactus 🌵, Aloé vera 🪴, Plante feu 🔥, Dattier 🌴");

        Console.WriteLine("🐜 Nuisibles locaux :");
        Console.WriteLine("   - Chomps des sables : détruisent les racines des plantes.");
        Console.WriteLine("   - Scaraboss : scarabées destructeurs.");
        Console.WriteLine("   - Tempêtes de sable : balayent les plantes fragiles.\n");
    }

    /*
        Initialise une illustration ASCII représentant le Désert Chomp.
    */
    public override void InitialiserIllustration()
    {
        this.Illustration  = "            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⣀⣀⠀⠀⠀⣀⠀⠀\n";
        this.Illustration += "            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠙⠛⠛⠛⠛⠷⠶⠀⣾⣿⣿⣷⠈⠛⠉⠁⠀\n";
        this.Illustration += "            ⠀⠀⠀⠀⠀⠀⠀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⡦⠈⠛⠛⢁⠀⠀⠀⠀⠀\n";
        this.Illustration += "            ⠀⠀⠀⠀⠀⠀⢸⣿⡇⠀⠀⠀⠀⠀⠀⠀⣀⣴⠟⠁⢀⣾⠃⠀⠹⣧⠀⠀⠀⠀\n";
        this.Illustration += "            ⠀⠀⠀⠈⡇⠀⢸⣿⡇⠀⠀⠀⠀⠀⠀⠀⠈⠁⠀⠀⣼⠇⠀⠀⠀⠙⡇⠀⠀⠀\n";
        this.Illustration += "            ⠀⠀⠀⠀⠿⠶⢾⣿⡇⠀⢸⡇⠀⠀⠀⠀⠀⠀⠀⣰⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀\n";
        this.Illustration += "            ⠀⠀⠀⠀⠀⠀⢸⣿⡇⠀⣿⡇⠀⠀⠀⠀⠀⠀⢀⡿⠀⠀⠀⠀⣀⢸⡆⣠⠀⠀\n";
        this.Illustration += "            ⠀⠀⠀⠀⠀⠀⢸⣿⣇⣠⣿⠃⠀⠀⠀⠀⠀⠀⠈⠁⠀⠀⠀⠀⣿⣼⡟⠋⠀⠀\n";
        this.Illustration += "            ⠀⢀⣀⣀⣀⡀⢸⣿⡿⠿⠛⢀⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⣼⣇⣀⡀⠀\n";
        this.Illustration += "            ⠀⢸⣿⣿⣿⡇⢸⣿⣧⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀\n";
        this.Illustration += "            ⠀⢸⣿⣿⣿⡇⢸⣿⣿⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀\n";
        this.Illustration += "            ⠀⢸⣿⣿⣿⡇⢸⣿⣿⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀\n";
        this.Illustration += "            ⠀⢸⣿⣿⣿⣇⠘⠿⠟⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀\n";
        this.Illustration += "            ⠀⢸⣿⣿⣿⣿⣿⣶⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀\n";
        this.Illustration += "            ⠀⠈⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠁⠀\n";
    }

    /*
        Gère une urgence spécifique au Désert Chomp.
    */
    public override void LancerUrgence(Terrain terrain1, Terrain terrain2)
    {
        int tirage = new Random().Next(3);

        switch (tirage)
        {
            case 0:
                GererChompDesSables(terrain1, terrain2);
                break;
            case 1:
                GererScaraboss(terrain1, terrain2);
                break;
            case 2:
                GererTempeteSable(terrain1, terrain2);
                break;
        }

        Thread.Sleep(2000);
        Console.WriteLine("\nL'urgence est terminée. Le soleil tape toujours aussi fort...");
        Simulation.AttendreUtilisateurPourContinuer();
    }

    /*
        Gère une tempête de sable violente.
        Cible uniquement les plantes non adultes.
        Si le joueur échoue, la plante est déracinée.
        La tempête de sable ne peut déraciner qu'une plante par urgence.

        param terrain1 : Premier terrain du joueur.
        param terrain2 : Deuxième terrain du joueur.
    */
    private static void GererTempeteSable(Terrain terrain1, Terrain terrain2)
    {
        GererAttaqueNuisible(
            nomNuisible: "🌪️ Tempête de sable",
            messageIntro: "Une tempête de sable se lève à l’horizon... Elle fonce sur votre jardin !",
            terrain1: terrain1,
            terrain2: terrain2,
            conditionCible: plante => plante.Croissance != Croissance.Adulte && plante.Etat == Etat.BonneSante,
            actionCible: (plante, terrain) =>
            {
                Affichage.AfficherAvertissement($"\nLa tempête déracine la {plante.Symbole} en {plante.Coordonnees} !");

                terrain.RetirerPlantesFilles(plante);
                terrain.Emplacements[plante.Coordonnees.X, plante.Coordonnees.Y] = null;
                terrain.Plantes.Remove(plante);
            },
            options:
            [
                ("Déployer une bâche de protection", 0.8),
                ("Créer un mur de sable", 0.6),
                ("Enterrer partiellement la plante", 0.7)
            ]
        );
    }

    /*
        Gère une attaque de Scaraboss (scarabée destructeur).
        Le scarabée s’attaque à une plante non adulte et fragile (taille ≤ 2).
        Si le joueur échoue à le repousser, la plante est mangée.

        param terrain1 : Premier terrain du joueur.
        param terrain2 : Deuxième terrain du joueur.
    */
    private static void GererScaraboss(Terrain terrain1, Terrain terrain2)
    {
        GererAttaqueNuisible(
            nomNuisible: "🪲 Scaraboss",
            messageIntro: "Un Scaraboss surgit du sable brûlant et fonce vers vos plantations !",
            terrain1: terrain1,
            terrain2: terrain2,
            conditionCible: plante => plante.Etat == Etat.BonneSante && plante.TailleAdulte <= 2 && plante.Croissance != Croissance.Adulte,
            actionCible: (plante, terrain) =>
            {
                Affichage.AfficherAvertissement($"\nLe Scaraboss dévore votre jeune {plante.Symbole} en {plante.Coordonnees} !");

                terrain.RetirerPlantesFilles(plante);
                terrain.Emplacements[plante.Coordonnees.X, plante.Coordonnees.Y] = null;
                terrain.Plantes.Remove(plante);
            },
            options:
            [
                ("Créer un mirage avec un miroir", 0.7),
                ("Taper des mains", 0.6),
                ("Secouer du sable en l’air", 0.8)
            ]
        );
    }

    /*
        Gère une attaque de Chomp des sables.
        Cible une plante aléatoire en bonne santé, peu importe sa taille.
        Si le joueur échoue, la plante est détruite.

        param terrain1 : Premier terrain du joueur.
        param terrain2 : Deuxième terrain du joueur.
    */
    private static void GererChompDesSables(Terrain terrain1, Terrain terrain2)
    {
        GererAttaqueNuisible(
            nomNuisible: "🦴 Chomp des sables",
            messageIntro: "Un Chomp géant surgit du sol et gronde violemment !",
            terrain1: terrain1,
            terrain2: terrain2,
            conditionCible: plante => plante.Etat == Etat.BonneSante,
            actionCible: (plante, terrain) =>
            {
                Affichage.AfficherAvertissement($"\nLe Chomp des sables dévore les racines de votre plante {plante.Symbole} en {plante.Coordonnees} !");

                terrain.RetirerPlantesFilles(plante);
                terrain.Emplacements[plante.Coordonnees.X, plante.Coordonnees.Y] = null;
                terrain.Plantes.Remove(plante);
            },
            options:
            [
                ("Faire vibrer le sol avec des outils", 0.7),
                ("Déployer un épouvantail géant", 0.6),
                ("Jeter des cailloux sur sa trajectoire", 0.65)
            ]
        );
    }
}