public class PlaineChampignon : Monde
{
    public PlaineChampignon(string unNom = "Plaine Champignon") : base(unNom)
    {
        // Sol disponible
        this.typesSolDisponibles.Add(TypeSol.Humifere);

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

    public override void AfficherDescription()
    {
        Console.WriteLine("𓍊 Monde 1 — Plaine Champignon 𓍊\n");

        Console.WriteLine("Bienvenue dans la Plaine Champignon, un monde doux et paisible où tout pousse... sauf quand un Goombavers passe par là !\n");

        Console.WriteLine("Caractéristiques :\n");
        Console.WriteLine("   - Température : 10°C à 25°C (tempéré)");
        Console.WriteLine("   - Météo : alternance pluie / soleil");
        Console.WriteLine("   - Plantes : Tomate, Fraise, Marguerite, Champignon\n");
    }

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

