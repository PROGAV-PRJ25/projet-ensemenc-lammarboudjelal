/*
    Représente un terrain cultivable.
    Un terrain possède un nom, un type de sol, et un espace 5x5 pour planter des plantes.
*/
public class Terrain(string unNom)
{
    private readonly string nom = unNom; // Nom du terrain.
    private TypeSol typeSol = default; // Type de sol (humifère, argileux, sableux...).
    private readonly Plante?[,] emplacements = new Plante?[5, 5]; // Grille de 5x5 représentant les emplacements de plantes.
    private readonly List<Plante> plantes = []; // Plantes plantées sur le terrain.

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
    public Plante?[,] Emplacements
    {
        get { return emplacements; }
    }

    /*
        Accesseur en lecture uniquement du nom du terrain.
    */
    public string Nom
    {
        get { return nom; }
    }

    /*
        Accesseur en lecture uniquement du plantes plantées sur le terrain.
    */
    public List<Plante> Plantes
    {
        get { return plantes; }
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
        if (this.emplacements[x, y] != null)
            return false;

        Plante nouvellePlante = Plante.CreerPlanteDepuisType(type, x, y);
        this.plantes.Add(nouvellePlante);
        this.emplacements[x,y] = nouvellePlante;
        return true;
    }

    /*
        Retrouve la plante parent d'une plante fille.

        param planteFille : Plante dont on souhaite récupérer le parent.

        return : Plante parente de la plante fille.
    */
    private Plante TrouverParent(Plante planteFille)
    {
        return this.plantes.Find(p => p == planteFille.PlanteParente)!;
    }

    /*
        Retire du terrain les plantes filles d'une plante.
        
        param planteParent : Plante dont on souhaite retirer les plantes filles du terrain.
    */
    public void RetirerPlantesFilles(Plante planteParente)
    {
        foreach (var planteFille in planteParente.PlantesFilles)
        {
            this.Emplacements[planteFille.Coordonnees.X, planteFille.Coordonnees.Y] = null;
        }
        planteParente.PlantesFilles.Clear();
    }

    /*
        Retire une plante du terrain à partir des coordonnées saisies.

        param x : Coordonnées en x de la parcelle où la plante doit être retirée.
        param y : Coordonnées en y de la parcelle où la plante doit être retirée.

        return : True si une plante a été retirée, false sinon.
    */
    public bool Desherber(int x, int y)
    {
        Plante? planteSelectionnee = this.emplacements[x, y];

        // Cas 1 : la plante à désherber n'existe pas, l'emplacement est vide.
        if (planteSelectionnee == null)
            return false;

        Plante plantePrincipale = planteSelectionnee;

        // Cas 2 : c’est une plante mère (pas de parent, mais a des filles).
        if (planteSelectionnee.PlanteParente == null && planteSelectionnee.PlantesFilles.Count != 0)
        {
            plantePrincipale = planteSelectionnee;
        }
        // Cas 3 : c’est une plante fille, on remonte au parent.
        else if (planteSelectionnee.PlanteParente != null)
        {
            plantePrincipale = this.TrouverParent(planteSelectionnee);
        }

        // Suppression des plantes filles si nécessaire.
        this.RetirerPlantesFilles(plantePrincipale);

        // Suppression de la plante principale.
        this.plantes.Remove(plantePrincipale);
        this.emplacements[plantePrincipale.Coordonnees.X, plantePrincipale.Coordonnees.Y] = null;
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
        Plante? planteSelectionnee = this.emplacements[x, y];

        if (planteSelectionnee == null)
            return false;
        
        // Si le joueur a sélectionné l'enfant d'une plante, il faut récupérer son parent (pour arroser à la racine O.o).
        if (planteSelectionnee.PlanteParente != null)
        {
            planteSelectionnee = this.TrouverParent(planteSelectionnee);
        }

        planteSelectionnee.Desalterer();
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
        Plante? planteSelectionnee = this.emplacements[x,y];

        if (planteSelectionnee == null)
            return (false, null, 0);

        // Si le joueur a sélectionné l'enfant d'une plante, il faut récupérer son parent.
        if (planteSelectionnee.PlanteParente != null)
        {
            planteSelectionnee = this.TrouverParent(planteSelectionnee);
        }

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
        Plante? planteSelectionnee = this.emplacements[x, y];


        if (planteSelectionnee == null)
            Affichage.AfficherAvertissement("Aucune plante n'est positionnée à ces coordonnées. C'est dommage, vous venez de perdre une action...");
        else
        {
            // Si le joueur a sélectionné l'enfant d'une plante, il faut récupérer son parent (pour la traiter à la racine O.o).
            if (planteSelectionnee.PlanteParente != null)
            {
                planteSelectionnee = this.TrouverParent(planteSelectionnee);
            }

            if (planteSelectionnee.Guerir())
                Affichage.AfficherSucces("Votre plante a été soignée, elle pète la forme !");
            else
                Affichage.AfficherAvertissement("Cette plante était déjà en bonne santé. C'est dommage, vous venez de perdre une action...");
        }
    }

    /*
        Met à jour toutes les plantes du terrain selon les conditions météorologiques, caractéristiques du terrain et ses conditions de vie.

        param meteo : Météo de la semaine impactant la plante.
    */
    public void MettreAJourPlantes(Meteo meteo)
    {
        foreach (var plante in this.plantes)
        {
            if (plante.Etat != Etat.Morte)
                plante.MettreAJour(meteo, this);
        }
    }
}