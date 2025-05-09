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
    TypeSol unSolPrefere,
    int unNbProductionsMaxPossible,
    int uneCoordX,
    int uneCoordY)
{
    protected string symbole = unSymbole; // Symbole affiché pour représenter la plante.
    protected TypePlante type = unType; // Type de la plante.
    protected int taille = uneTaille; // Taille de la plante.
    protected int besoinsEau = desBesoinsEau; // Besoins en eau en pourcentage.
    protected int besoinsLuminosite = desBesoinsLuminosite; // Besoins en lumière en pourcentage.
    protected int temperatureMin = uneTempMin; // Température minimale supportée par la plante.
    protected int temperatureMax = uneTempMax; // Température maximale supportée par la plante.
    protected int vitesseCroissance = uneVitesseCroissance; // Nombre de semaines nécessaires pour passer d'un âge à un autre.
    protected int esperanceVie = uneEsperanceVie; // Durée de vie restante à partir de l'âge adulte si rien de fâcheux ne lui arrive.
    protected TypeSol solPrefere = unSolPrefere; // Type de sol préféré par la plante (conditions de pouce optimale).
    protected int tauxArrosage = 0; // Niveau d'eau de la plante en pourcentage (par défaut 0%). 
    private const int QuantiteArrosage = 50; // Pourcentage d'eau ajouté à la plante suite à un arrosage.
    protected Etat etat = Etat.BonneSante; // État de santé (par défaut "Bonne santé").
    protected int age = 0; // Âge de la plante en nombre de semaines.
    protected Croissance croissance = Croissance.Semis; // Niveau de croissance de la plante (par défaut "Semis").
    protected int nbProductionsActuel = 0; // Nombre actuel de production de la plante (fruits, légumes...) (par défaut 0).
    protected int nbProductionsMaxPossible = unNbProductionsMaxPossible; // Nombre de production de la plante (fruits, légumes...) maximal possible.
    protected Dictionary<Maladie, int> ProbaMaladies { get; } = []; // Probabilité que la plante attrape une maladie donnée, exprimée en %.
    protected Maladie? maladieActuelle = null; // Maladie dont souffre actuellement la plante.
    protected int toursMalade = 0; // Compteur de tours de jeu où la plante est malade lorsqu'elle l'est.
    protected int x = uneCoordX; // Coordonnées en x de la plante.
    protected int y = uneCoordY; // Coordonnées en y de la plante.

    /*
        Accesseur en lecture uniquement du symbole affiché pour représenter la plante.
    */
    public string Symbole 
    { 
        get { return symbole; }
    }

    /*
        Accesseur en lecture uniquement de l'état de la plante.
    */
    public Etat Etat 
    { 
        get { return etat; }
    }

    /*
        Accesseur en lecture uniquement du nombre de production maximal que peut donner la plante.
    */
    public int NbProductionsMaxPossible 
    { 
        get { return nbProductionsMaxPossible; }
    }

    /*
        Accesseur en lecture et écriture du nombre de production actuel de la plante.
    */
    public int NbProductionsActuel 
    { 
        get { return nbProductionsActuel; }
        set { nbProductionsActuel = value; }
    }

    /*
        Accesseur en lecture uniquement du type de la plante.
    */
    public TypePlante Type 
    { 
        get { return type; }
    }

    /*
        Accesseur en lecture uniquement de l'emplacement en x de la plante.
    */
    public int X 
    { 
        get { return x; }
    }

    /*
        Accesseur en lecture uniquement de l'emplacement en y de la plante.
    */
    public int Y 
    { 
        get { return y; }
    }

    /*
        Retourne une description textuelle de la plante.

        return : Chaîne de caractères décrivant l'état actuel de la plante.
    */
    public override string ToString()
    {
        string plante = $"{this.type} {this.symbole} :\n";
        plante += $"  - État : {this.etat}\n";
        if(this.etat == Etat.BonneSante) plante += $"  - Croissance : {this.croissance}\n";
        plante += $"  - Taux d'arrosage : {this.tauxArrosage}%\n";
        plante += $"  - Production : {this.nbProductionsActuel}\n";

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
        Incrémente le taux d'arrosage de la plante de 50%.
    */
    public void Desalterer()
    {
        this.tauxArrosage += QuantiteArrosage;
    }

    /*
        Ajuste le taux d’arrosage d’une plante avec la pluie et vérifie s’il est mortel.
        La plante meurt si son taux d'arrosage est supérieur ou inférieur à 50% de ses besoins.

        param meteo : Météo actuelle (taux de précipitation utilisée).
    */
    private void AjusterArrosage(Meteo meteo)
    {
        this.tauxArrosage += meteo.TauxPluie;

        if (this.tauxArrosage < 0.5 * this.besoinsEau || this.tauxArrosage > 1.5 * this.besoinsEau)
        {
            this.etat = Etat.Morte;
        }
    }

    /*
        Vérifie si la température actuelle est mortelle pour la plante.
        La plante meurt si la température supérieur ou inférieur à 50% de ses besoins.

        param meteo : Météo actuelle (température utilisée).
    */
    private void VerifierTemperature(Meteo meteo)
    {
        if (meteo.Temperature < this.temperatureMin || meteo.Temperature > this.temperatureMax)
        {
            this.etat = Etat.Morte;
        }
    }

    /*
        Vérifie si la plante adulte a dépassé sa durée de vie naturelle.
        La durée de vie maximale est : (3 * vitesse de croissance) + espérance de vie.
        Multiplier par 3 permet de prendre en compte les niveaux de croissance précédant l'âge adulte (semis, bebe, adolescent).
        La plante meurt si elle a dépassé cette durée maximale.
        Quand une plante meurt, ses productions sont perdues si elles n'ont pas été récoltées.
    */
    private void GererVieillissement()
    {
        if (this.age >= 3 * this.vitesseCroissance + this.esperanceVie)
        {
            this.etat = Etat.Morte;
            this.nbProductionsActuel = 0; 
        }
    }

    /*
        Incrémente l'âge de la plante. 
        Si les conditions de croissance sont parfaites, elle grandit plus vite. 
        À certaines étapes, elle change d'état de croissance.

        param meteo : Météo actuelle (taux d'ensoleillement utilisée).
        param typeSol : Type de sol sur lequel pousse la plante.
    */
    private void GererCroissance(Meteo meteo, TypeSol typeSol)
    {
        // Conditions parfaites : bon sol, luminosité ±10%, arrosage ±10%
        bool conditionsParfaites =
            this.solPrefere == typeSol &&
            Math.Abs(this.besoinsLuminosite - meteo.TauxEnsoleillement) <= 10 &&
            Math.Abs(this.tauxArrosage - this.besoinsEau) <= 0.1 * this.besoinsEau;

        this.age += conditionsParfaites ? 2 : 1;

        // Passage d’étape jusqu'à l'âge adulte (semis < bebe < adolescent < adulte)
        if (this.age % this.vitesseCroissance == 0 && this.croissance != Croissance.Adulte)
        {
            this.croissance += 1;
        }
    }

    /*
        Si la plante est adulte et non récoltée, elle produit automatiquement.
    */
    private void GererProduction()
    {
        if (this.croissance == Croissance.Adulte && this.nbProductionsActuel == 0)
        {
            this.nbProductionsActuel = this.nbProductionsMaxPossible; 
        }
    }

    /*
        Réduit le taux d’arrosage par deux en fin de semaine.
    */
    private void ReduireArrosage()
    {
        this.tauxArrosage /= 2;
    }

    /*
        Tente de contaminer la plante avec l'une des maladies dont elle est sensible.
        Si la plante est déjà malade depuis 2 tours, elle meurt.
        La plante ne peut attraper qu'une maladie à la fois.
    */
    private void TenterContamination()
    {
        if (this.etat == Etat.Malade)
        {
            this.toursMalade++;
            if (this.toursMalade >= 2)
            {
                this.etat = Etat.Morte;
                return;
            }
            return;
        }

        // Tentative de contamination : 
        //  - un nombre aléatoire est tiré entre 1 et 100,
        //  - si ce nombre est inférieur ou égale à la probabilité de contamination 
        //    de la maladie, alors la plante tombe malade.
        foreach (var proba in ProbaMaladies)
        {
            int tirage = Random.Shared.Next(1,101);
            if (tirage <= proba.Value)
            {
                this.maladieActuelle = proba.Key;
                this.etat = Etat.Malade;
                return;
            }
        }
    }

    /*
        Applique tous les effets de la météo et du temps sur une plante à chaque fin de tour.

        param meteo : Météo actuelle.
        param typeSol : Type de sol du terrain sur lequel la plante est cultivée.
    */
    public void MettreAJour(Meteo meteo, TypeSol typeSol)
    {
        this.AjusterArrosage(meteo);
        this.VerifierTemperature(meteo);
        if (this.croissance == Croissance.Adulte) this.GererVieillissement();
        if (this.etat != Etat.BonneSante) 
        {
            // Tant qu'une plante est malade, elle ne peut ni grandir, ni produire.
            if (this.etat == Etat.BonneSante)
            {
                this.GererCroissance(meteo, typeSol);
                this.GererProduction();
            }
            this.ReduireArrosage();
            this.TenterContamination();
        }
    }

    /*
        Soigne la plante si elle est malade.

        return : True si la plante était malade et qu'elle est de nouveau sur pieds, false sinon.
    */
    public bool Guerir()
    {
        if (this.etat == Etat.Malade)
        {
            this.maladieActuelle = null;
            this.etat = Etat.BonneSante;
            this.toursMalade = 0;
            return true;
        }
        return false;
    }

    /*
        Crée une instance de plante en fonction du type.

        param type : Type de la plante à créer.
        param x : Coordonnées d'emplacement en x de la plante.
        param y : Coordonnées d'emplacement en y de la plante.

        return : Instance de plante.
    */
    public static Plante CreerPlanteDepuisType(TypePlante type, int x, int y)
    {
        return type switch
        {
            TypePlante.Tomate => new Tomate(x, y),
            TypePlante.Fraise => new Fraise(x, y),
            TypePlante.Marguerite => new Marguerite(x, y),
            TypePlante.Champignon => new Champignon(x, y),
            _=> throw new Exception("Type de plante inconnu.")
        };
    }

    /*
        Affiche la description d'une plante en fonction du type.

        param type : Type de la plante dont la description doit être affichée.

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

    /*
        Indique le nombre de production d'une plante selon son type.

        param type : Type de la plante dont on souhaite récupérer le nombre maximal de production possible.

        return : Le nombre de production de la plante.
    */
    public static int IndiquerNbProductionsSelonType(TypePlante type)
    {
        return type switch
        {
            TypePlante.Tomate => new Tomate().NbProductionsMaxPossible,
            TypePlante.Fraise => new Fraise().NbProductionsMaxPossible,
            TypePlante.Marguerite => new Marguerite().NbProductionsMaxPossible,
            TypePlante.Champignon => new Champignon().NbProductionsMaxPossible,
            _=> throw new Exception("Type de plante inconnu.")
        };
    }

    /*
        Méthode abstraite pour initialiser les probabilités de maladies spécifiques à la plante.
    */
    protected abstract void InitialiserProbabilitesMaladies();
}