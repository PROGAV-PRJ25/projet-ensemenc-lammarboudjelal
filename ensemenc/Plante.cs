/*
    Classe abstraite représentant une plante de jeu.
*/
public abstract class Plante(
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
    protected string symbole = unSymbole; // Symbole affiché pour représenter la plante.
    protected TypePlante type = unType; // Type de la plante.
    protected int taille = uneTaille; // Taille de la plante.
    protected int besoinsEau = desBesoinsEau; // Besoins en eau en pourcentage.
    protected int besoinsLuminosite = desBesoinsLuminosite; // Besoins en lumière en pourcentage.
    protected int temperatureMin = uneTempMin; // Température minimale supportée par la plante.
    protected int temperatureMax = uneTempMax; // Température maximale supportée par la plante.
    protected int vitesseCroissance = uneVitesseCroissance; // Nombre de semaines nécessaires pour atteindre la maturité (l'âge adulte).
    protected int esperanceVie = uneEsperanceVie; // Espérance de vie de la plante en nombre de semaines si elle n'est pas récoltée.
    protected TypeSol solPrefere = unSolPrefere; // Type de sol préféré par la plante (conditions de pouce optimale).
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
        Retourne une description textuelle de la plante.

        return : Chaîne de caractères décrivant l'état actuel de la plante.
    */
    public override string ToString()
    {
        string plante = $"{this.type} {this.symbole} :\n";
        plante += $"  - État : {this.etat}\n";
        plante += $"  - Croissance : {this.croissance}\n";
        plante += $"  - Taux d'arrosage : {this.tauxArrosage}%\n";
        plante += $"  - Production : {this.productions}\n";

        return plante;
    }

    /*
        Affiche les caractéristiques d'une plante.

        return : Chaîne de caractères décrivant les caractéristiques de la plante.
    */
    public string AfficherCaracteristiques()
    {
        string caracteristiques = $"      - Sol préféré : {this.solPrefere}\n";
        caracteristiques += $"      - Taille : {this.taille}\n";
        caracteristiques += $"      - Besoins : {this.besoinsEau}% en eau et {this.besoinsLuminosite}% en luminosité\n";
        caracteristiques += $"      - Température de survie : entre {this.temperatureMin}°C et {this.temperatureMax}°C\n";
        caracteristiques += $"      - Vitesse de croissance : {this.vitesseCroissance} semaines pour atteindre l'âge adulte\n";

        return caracteristiques;
    }

    /*
        Crée une instance de plante en fonction du type.

        return : Instance de plante.
    */
    public static Plante CreerPlanteDepuisType(TypePlante type)
    {
        return type switch
        {
            TypePlante.Tomate => new Tomate(),
            TypePlante.Fraise => new Fraise(),
            TypePlante.Marguerite => new Marguerite(),
            TypePlante.Champignon => new Champignon(),
            _=> throw new Exception("Type de plante inconnu.")
        };
    }

    /*
        Affiche la description d'une plante en fonction du type.

        return : La description de la plante.
    */
    public static string AfficherDescription(TypePlante type)
    {
        return type switch
        {
            TypePlante.Tomate => $"{new Tomate().AfficherCaracteristiques()}",
            TypePlante.Fraise => $"{new Fraise().AfficherCaracteristiques()}",
            TypePlante.Marguerite => $"{new Marguerite().AfficherCaracteristiques()}",
            TypePlante.Champignon => $"{new Champignon().AfficherCaracteristiques()}",
            _=> throw new Exception("Type de plante inconnu.")
        };
    }
}