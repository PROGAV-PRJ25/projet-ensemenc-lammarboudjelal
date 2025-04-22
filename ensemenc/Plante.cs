public abstract class Plante
{
    protected string nom;
    protected string symbole;
    protected TypePlante type;
    protected int taille;
    protected int besoinsEau;
    protected int besoinsLuminosite;
    protected int temperatureMin;
    protected int temperatureMax;
    protected int vitesseCroissance;
    protected int esperanceVie;
    protected TypeSol solPrefere;
    protected int tauxArrosage = 0;
    protected Etat etat = Etat.BonneSante;
    protected Croissance croissance = Croissance.Semi;
    protected int productions = 0;

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