/*
    Classe abstraite représentant une plante de jeu.
*/
public abstract class Plante(
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
    protected string nom = unNom; // Nom de la plante.
    protected string symbole = unSymbole; // Symbole affiché pour représenter la plante.
    protected TypePlante type = unType; // Type de la plante.
    protected int taille = uneTaille; // Taille de la plante sur la grille à l'âge adulte.
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