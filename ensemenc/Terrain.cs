/*
    Représente un terrain cultivable.
    Un terrain possède un nom, un type de sol, et un espace 5x5 pour planter des plantes.
*/
public class Terrain(string unNom)
{
    private readonly string nom = unNom; // Nom du terrain.
    private TypeSol typeSol = default; // Type de sol (humifère, argileux, sableux...).
    private readonly Plante?[,] plantes = new Plante?[5, 5]; // Grille de 5x5 représentant les emplacements de plantes.

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
        Sème une plante du type donné à l'emplacement (x, y) si possible.

        param type : Le type de plante à semer.
        param x : Coordonnées en x de la parcelle où la plante doit être semée.
        param y : Coordonnées en y de la parcelle où la plante doit être semée.

        return : True si la semence s'est faite, false sinon.
    */
    public bool Semer(TypePlante type, int x, int y)
    {
        if (this.plantes[x, y] != null)
            return false;

        this.plantes[x,y] = Plante.CreerPlanteDepuisType(type);
        return true;
    }

    /*
        Retire une plante du terrain à partir des coordonnées saisies.

        param x : Coordonnées en x de la parcelle où la plante doit être retirée.
        param y : Coordonnées en y de la parcelle où la plante doit être retirée.

        return : True si une plante a été retirée, false sinon.
    */
    public bool Desherber(int x, int y)
    {
        if (this.plantes[x, y] == null)
            return false;
        
        this.plantes[x,y] = null;
        return true;
    }

    /*
        Arrose une plante du terrain à partir des coordonnées saisies.
        Un arrosage ajoute 50% d'eau au taux d'arrosage d'une plante.

        param x : Coordonnées en x de la parcelle à arroser.
        param y : Coordonnées en y de la parcelle à arroser.

        return : True si une plante a été arrosée, false sinon.
    */
    public bool Arroser(int x, int y)
    {
        if (this.plantes[x, y] == null)
            return false;
        
        this.plantes[x,y]!.Desalterer();
        return true;
    }

    /*
        Récolte les productions d'une plante si possible.

        param x : Coordonnées en x de la parcelle où la plante doit être récoltée.
        param y : Coordonnées en y de la parcelle où la plante doit être récoltée.

        return : Un tuple contenant :
                    - bool : true si une plante est présente à l'emplacement sélectionnée par le joueur,
                    - TypePlante? : le type de la plante (null si pas de plante),
                    - int : la quantité de production récoltée (0 si aucune production).
    */
    public (bool plantePresente, TypePlante? type, int quantite) Recolter(int x, int y)
    {
        Plante? planteSelectionnee = this.plantes[x,y];

        if (planteSelectionnee == null)
            return (false, null, 0);

        int quantite = planteSelectionnee.NbProductionsActuel;
        TypePlante type = planteSelectionnee.Type;
        
        planteSelectionnee.NbProductionsActuel = 0;

        return (true, type, quantite);
    }

    /*
        Traite une plante du terrain si possible.

        param x : Coordonnées en x de la parcelle à traiter.
        param y : Coordonnées en y de la parcelle à traiter.
    */
    public void Traiter(int x, int y)
    {    
        Plante? planteSelectionnee = this.plantes[x,y];

        if (planteSelectionnee == null)
            Console.WriteLine("Aucune plante n'est positionnée à ces coordonnées. C'est dommage, vous venez de perdre une action...");
        else if (planteSelectionnee.Guerir())
            Console.WriteLine("Votre plante a été soignée, elle pète la forme !");
        else
            Console.WriteLine("Cette plante était déjà en bonne santé. C'est dommage, vous venez de perdre une action...");
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
                    plante.MettreAJour(meteo, this.typeSol);
            }
        }
    }
}