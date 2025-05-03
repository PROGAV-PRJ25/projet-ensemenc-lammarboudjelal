/*
    Représente un terrain cultivable.
    Un terrain possède un nom, un type de sol, et un espace 5x5 pour planter des plantes.
*/
public class Terrain(string unNom)
{
    private string nom = unNom; // Nom du terrain.
    private TypeSol typeSol = default; // Type de sol (humifère, argileux, sableux...).
    private Plante [,] plantes = new Plante [5, 5]; // Grille de 5x5 représentant les emplacements de plantes.

    /*
        Accesseur en lecture et écriture du type de sol du terrain.
    */
    public TypeSol TypeSol
    {
        get { return typeSol; }
        set { typeSol = value; }
    }

    /*
        Accesseur en lecture uniquement de la grille représentant les emplacements de plantes.
    */
    public Plante[,] Plantes
    {
        get { return plantes; }
    }
    
    /*
        Sème une plante du type donné à l'emplacement (x, y) si possible.

        param type : Le type de plante à semer.

        return : True si la semence s'est faite, false sinon.
    */
    public bool Semer(TypePlante type)
    {
        // Choix des coordonnées de semence.
        Console.WriteLine("Coordonnées de la graine :");
        int x = Simulation.SaisirEntier("Ligne ", 1, 5) - 1; // -1 car un tableau commence à l'indice 0.
        int y = Simulation.SaisirEntier("Colonne ", 1, 5) - 1;

        // Emplacement déjà occupé.
        if (this.plantes[x, y] != null)
        {
            Console.WriteLine($"L'emplacement est déjà occupé par {this.plantes[x, y].Symbole}. C'est dommage, vous venez de perdre une graine...");
            return false;
        }

        this.plantes[x,y] = Plante.CreerPlanteDepuisType(type);

        return true;
    }
}