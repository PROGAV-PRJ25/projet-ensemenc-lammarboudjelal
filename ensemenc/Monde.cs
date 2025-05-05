/*
    Classe abstraite représentant un monde de jeu.
*/
public abstract class Monde(string unNom)
{
    protected string nom = unNom; // Nom du monde.
    protected Meteo meteoPrevisionnelle = new(0, 0, 0); // Météo prévisionnelle de la semaine à venir dans le monde.
    protected List<Meteo> meteosPossibles = []; // Liste des météos possibles dans ce monde.
    protected List<TypePlante> typesPlanteDisponibles = []; // Liste des types de plantes disponibles.
    protected List<TypeSol> typesSolsDisponibles = []; // Liste des types de sols disponibles.

    /*
        Accesseur en lecture uniquement du nom du monde.
    */
    public string Nom
    {
        get { return nom; }
    }

    /*
        Accesseur en lecture uniquement de la liste des météos possibles dans ce monde.
    */
    public List<Meteo> MeteosPossibles 
    { 
        get { return meteosPossibles; }
    } 

    /*
        Accesseur en lecture uniquement de la liste des types de plantes disponibles.
    */
    public List<TypePlante> TypesPlanteDisponibles 
    { 
        get { return typesPlanteDisponibles; } 
    } 

    /*
        Accesseur en lecture uniquement de la liste des sols disponibles.
    */
    public List<TypeSol> TypesSolsDisponibles 
    { 
        get { return typesSolsDisponibles; } 
    }

    /*
        Accesseur en lecture uniquement de la météo prévisionnelle.
    */
    public Meteo MeteoPrevisionnelle
    {
         get { return meteoPrevisionnelle; } 
    }

    /*
        Défini la météo actuelle en sélectionnant aléatoirement une des météos possibles du monde.
    */
    public void DefinirMeteoPrevisionnelle()
    {
        Random rnd = new();
        int indexMeteo = rnd.Next(this.meteosPossibles.Count);
        this.meteoPrevisionnelle = this.meteosPossibles[indexMeteo];
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