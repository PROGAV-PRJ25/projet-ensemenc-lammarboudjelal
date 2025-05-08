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
        Un arrosage ajoute 50% d'eau au taux d'arrosage d'une plante.

        return : True si une plante a été arrosée, false sinon.
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

    /*
        Met à jour toutes les plantes du terrain selon les conditions météorologiques, caractéristiques du terrain et ses conditions de vie.

        param meteo : Météo de la semaine impactant la plante.
    */
    public void MettreAJourPlantes(Meteo meteo)
    {
        for (int i = 0; i < this.plantes.GetLength(0); i++)
        {
            for (int j = 0; j < this.plantes.GetLength(1); j++)
            {
                Plante? plante = this.plantes[i, j];
                if (plante != null && plante.Etat != Etat.Morte)
                {
                    plante.MettreAJour(meteo, this.typeSol);
                }
            }
        }
    }

    /*
        Récolte les productions d'une plante si possible.

        return : Un tuple contenant :
                    - bool : true si une plante est présente à l'emplacement sélectionnée par le joueur,
                    - TypePlante? : le type de la plante (null si pas de plante),
                    - int : la quantité de production récoltée (0 si aucune production).
    */
    public (bool plantePresente, TypePlante? type, int quantite) Recolter()
    {
        var (x, y) = SaisirCoordonnees("récolter");

        Plante? planteSelectionnee = this.plantes[x,y];

        if (planteSelectionnee == null)
        {
            return (false, null, 0);
        }

        int quantite = planteSelectionnee.NbProductionsActuel;
        TypePlante type = planteSelectionnee.Type;
        
        planteSelectionnee.NbProductionsActuel = 0;

        return (true, type, quantite);
    }

    /*
        Traite une plante du terrain si possible.
    */
    public void Traiter()
    {
        var (x, y) = SaisirCoordonnees("soigner");
        
        Plante? planteSelectionnee = this.plantes[x,y];

        if (planteSelectionnee == null)
            Console.WriteLine("Aucune plante n'est positionnée à ces coordonnées. C'est dommage, vous venez de perdre une action...");
        else if (planteSelectionnee.Guerir())
            Console.WriteLine("Votre plante a été soignée, elle pète la forme !");
        else
            Console.WriteLine("Cette plante était déjà en bonne santé. C'est dommage, vous venez de perdre une action...");
    }
}