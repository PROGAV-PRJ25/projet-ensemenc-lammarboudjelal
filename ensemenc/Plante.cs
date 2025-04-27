/*
    Classe abstraite représentant une plante de jeu.
*/
public abstract class Plante
{
    protected string nom; // Nom de la plante.
    protected string symbole; // Symbole affiché pour représenter la plante.
    protected TypePlante type; // Type de la plante.
    protected int taille; // Taille de la plante sur la grille à l'âge adulte.
    protected int besoinsEau; // Besoins en eau en pourcentage.
    protected int besoinsLuminosite; // Besoins en lumière en pourcentage.
    protected int temperatureMin; // Température minimale supportée par la plante.
    protected int temperatureMax; // Température maximale supportée par la plante.
    protected int vitesseCroissance; // Nombre de semaines nécessaires pour atteindre la maturité (l'âge adulte).
    protected int esperanceVie; // Espérance de vie de la plante en nombre de semaines si elle n'est pas récoltée.
    protected TypeSol solPrefere; // Type de sol préféré par la plante (conditions de pouce optimale).
    protected int tauxArrosage = 0; // Niveau d'eau de la plante en pourcentage (par défaut 0%). 
    protected Etat etat = Etat.BonneSante; // État de santé (par défaut "Bonne santé").
    protected Croissance croissance = Croissance.Semi; // Niveau de croissance de la plante (par défaut "Semi").
    protected int productions = 0; // Nombre de production de la plante (fruits, légumes...) (par défaut 0).

    /*
        Accesseur en lecture uniquement du symbole affiché pour représenter la plante.
    */
    public string Symbole 
    { 
        get { return symbole; }
    } 

    /* 
        Constructeur de la classe Plante.

        param unNom : Nom de la plante.
        param unSymbole : Symbole affiché pour représenter la plante.
        param unType : Type de la plante.
        param uneTaille : Taille de la plante sur la grille à l'âge adulte.
        param desBesoinsEau : Besoins en eau en pourcentage.
        param desBesoinLuminosite : Besoins en lumière en pourcentage.
        param uneTempMin : Température minimale supportée par la plante.
        param uneTempMax : Température maximale supportée par la plante.
        param uneVitesseCroissance : Nombre de semaines nécessaires pour atteindre la maturité (l'âge adulte).
        param uneEsperanceVie : Espérance de vie de la plante en nombre de semaines si elle n'est pas récoltée.
        param unSolPrefere : Type de sol préféré par la plante (conditions de pouce optimale).
    */
    public Plante(
        string unNom,
        string unSymbole, 
        TypePlante unType, 
        int uneTaille, 
        int desBesoinsEau, 
        int desBesoinsLuminosite, 
        int uneTempMin, 
        int uneTempMax, 
        int uneVitesseCroissance, 
        int uneEsperanceVie, 
        TypeSol unSolPrefere)
    {
        this.nom = unNom;
        this.symbole = unSymbole;
        this.type = unType;
        this.taille = uneTaille;
        this.besoinsEau = desBesoinsEau;
        this.besoinsLuminosite = desBesoinsLuminosite;
        this.temperatureMin = uneTempMin;
        this.temperatureMax = uneTempMax;
        this.vitesseCroissance = uneVitesseCroissance;
        this.esperanceVie = uneEsperanceVie;
        this.solPrefere = unSolPrefere;
    }

    /*
        Retourne une description textuelle de la plante.

        return : Chaîne de caractères décrivant la plante.
    */
    public override string ToString()
    {
        string plante = $"{this.nom} {this.symbole} :\n";
        plante += $"  - État : {this.etat}\n";
        plante += $"  - Croissance : {this.croissance}\n";
        plante += $"  - Taux d'arrosage : {this.tauxArrosage}%\n";
        plante += $"  - Besoins : {this.besoinsEau}% en eau et {this.besoinsLuminosite}% en luminosité\n";
        plante += $"  - Production : {this.productions}\n";

        return plante;
    }
}