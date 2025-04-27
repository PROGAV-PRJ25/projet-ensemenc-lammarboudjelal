/*
    Représente le monde de la Plaine Champignon, tempéré, adapté aux cultures classiques.
    Hérite de la classe Monde et initialise ses caractéristiques propres.
*/
public class PlaineChampignon : Monde
{
    /*
        Constructeur de Plaine Champignon.
        Initialise le sol, les plantes et les météos typiques du monde.

        param unNom : Nom du monde (par défaut "Plaine Champignon").
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
        this.meteosPossibles.Add(new Meteo(20, 70, 10)); // Journée ensoleillée
        this.meteosPossibles.Add(new Meteo(15, 50, 40)); // Pluie légère
        this.meteosPossibles.Add(new Meteo(18, 60, 20)); // Météo douce
        this.meteosPossibles.Add(new Meteo(22, 80, 5));  // Beau temps
        this.meteosPossibles.Add(new Meteo(12, 30, 60)); // Fortes pluies
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
        Affiche une illustration ASCII représentant la Plaine Champignon.
    */
    public override void AfficherIllustration()
    {
        Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⣀⣀⡤⠤⢤⣀⡀");
        Console.WriteLine("         ⠀⠀⠀⢀⡤⠚⠉⠑⣀⠔⠐⠢⠀⠈⡹⠶⣄");
        Console.WriteLine("         ⠀⠀⡰⠋⠀⠀⠀⠀⡏⢄⣀⡰⢠⠊⠀⠀⠈⠳⡄");
        Console.WriteLine("         ⠀⣸⣅⡀⠀⠀⣀⠔⠀⢀⡀⠀⠸⡀⠀⠀⠀⠀⢸⡄");
        Console.WriteLine("         ⢀⣿⣿⣾⡭⡭⠐⢢⠊⠁⠈⢣⠀⠙⠢⢄⣠⣴⣿⣷");
        Console.WriteLine("         ⢸⠁⠀⠈⠹⣿⣶⣼⣆⣀⣀⣼⣠⣤⣾⣿⠟⠉⠙⢿");
        Console.WriteLine("         ⠈⢧⡀⠀⣠⣿⡿⠿⠿⠿⠿⠿⠿⠿⣿⣿⡀⠀⣀⠞");
        Console.WriteLine("         ⠀⠀⠈⠉⢩⠃⠀⢀⣤⠀⠀⢠⣦⠀⠀⢸⠉⠉");
        Console.WriteLine("         ⠀⠀⠀⠀⢸⠀⠀⠀⠉⡀⠀⢈⠁⠀⠀⢸");
        Console.WriteLine("         ⠀⠀⠀⠀⠘⣆⠀⠀⠀⠉⠂⠁⠀⠀⢀⡼");
        Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠉⠉⠉⠉⠉⠉⠉⠉⠉");
    }
}

