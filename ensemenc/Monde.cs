/*
    Classe abstraite représentant un monde de jeu.
*/
public abstract class Monde
{
    protected string nom; // Nom du monde.
    protected List<Meteo> meteosPossibles = []; // Liste des météos possibles dans ce monde.
    protected List<TypePlante> typesPlanteDisponibles = []; // Liste des types de plantes disponibles.
    protected List<TypeSol> typesSolsDisponibles = []; // Liste des types de sols disponibles.
    public List<TypeSol>? TypesSolsDisponibles {get;} // Accesseur en lecture uniquement de la liste des sols disponibles.

    /*
        Constructeur de la classe Monde.

        param unNom : Nom du monde.
    */
    public Monde(string unNom)
    {
        this.nom = unNom;
    }

    /*
        Méthode abstraite pour afficher la description du monde.
    */
    public abstract void AfficherDescription();

    /*
        Méthode abstraite pour afficher une illustration ASCII du monde.
    */
    public abstract void AfficherIllustration();
}