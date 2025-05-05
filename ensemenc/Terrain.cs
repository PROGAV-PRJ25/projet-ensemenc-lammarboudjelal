/*
    Représente un terrain cultivable.
    Un terrain possède un nom, un type de sol, et un espace 5x5 pour planter des plantes.
*/
public class Terrain(string unNom)
{
    private string nom = unNom; // Nom du terrain.
    private TypeSol typeSol = default; // Type de sol (humifère, argileux, sableux...).
    private Plante?[,] plantes = new Plante?[5, 5]; // Grille de 5x5 représentant les emplacements de plantes.

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
    public Plante?[,] Plantes
    {
        get { return plantes; }
    }

    /*
        Accesseur en lecture uniquement du nom du terrain.
    */
    public string Nom
    {
        get { return nom; }
    }

    /*
        Demande les coordonnées à l'utilisateur et retourne (x, y).
    
        return : Tuple (x, y) si l'utilisateur entre des valeurs valides.
    */
    private static (int x, int y) SaisirCoordonnees(string action)
    {
        Console.WriteLine($"Coordonnées de la plante à {action} :");
        int x = Simulation.SaisirEntier("Ligne ", 1, 5) - 1; // -1 car un tableau commence à l'indice 0.
        int y = Simulation.SaisirEntier("Colonne ", 1, 5) - 1;
        return (x, y);
    }
    
    /*
        Sème une plante du type donné à l'emplacement (x, y) si possible.

        param type : Le type de plante à semer.

        return : True si la semence s'est faite, false sinon.
    */
    public bool Semer(TypePlante type)
    {
        var (x,y) = SaisirCoordonnees("semer");

        if (this.plantes[x, y] != null)
        {
            Console.WriteLine($"L'emplacement est déjà occupé par {this.plantes[x, y]!.Symbole}. C'est dommage, vous venez de perdre une graine...");
            return false;
        }

        this.plantes[x,y] = Plante.CreerPlanteDepuisType(type);

        return true;
    }

    /*
        Retire une plante du terrain à partir des coordonnées saisies.

        return : True si une plante a été retirée, false sinon.
    */
    public bool Desherber()
    {
        var (x, y) = SaisirCoordonnees("retirer");

        if (this.plantes[x, y] == null)
        {
            Console.WriteLine("Aucune plante n'est positionnée à ces coordonnées. C'est dommage, vous venez de perdre une action...");
            return false;
        }
        
        this.plantes[x,y] = null;
        return true;
    }

    /*
        Arrose une plante du terrain à partir des coordonnées saisies.
        Un arrosage ajoute 50%
    */
    public bool Arroser()
    {
        var (x, y) = SaisirCoordonnees("arroser");

        if (this.plantes[x, y] == null)
        {
            Console.WriteLine("Aucune plante n'est positionnée à ces coordonnées. C'est dommage, vous venez de perdre une action...");
            return false;
        }
        
        this.plantes[x,y]!.Desalterer();

        return true;
    }
}