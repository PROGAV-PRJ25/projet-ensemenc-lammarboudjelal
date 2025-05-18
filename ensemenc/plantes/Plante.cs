/*
    Classe abstraite représentant une plante de jeu.
*/
public abstract class Plante(
    string unSymbole,
    TypePlante unType,
    int uneTailleAdulte,
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
    protected int tailleAdulte = uneTailleAdulte; // Taille de la plante à l'âge adulte (taille max).
    protected int tailleActuelle = 1; // Taille actuelle de la plante, démarre à 1.
    protected int besoinsEau = desBesoinsEau; // Besoins en eau en pourcentage.
    protected int besoinsLuminosite = desBesoinsLuminosite; // Besoins en lumière en pourcentage.
    protected int temperatureMin = uneTempMin; // Température minimale supportée par la plante.
    protected int temperatureMax = uneTempMax; // Température maximale supportée par la plante.
    protected int vitesseCroissance = uneVitesseCroissance; // Nombre de semaines nécessaires pour passer d'un âge à un autre.
    protected int esperanceVie = uneEsperanceVie; // Durée de vie restante à partir de l'âge adulte si rien de fâcheux ne lui arrive.
    protected TypeSol solPrefere = unSolPrefere; // Type de sol préféré par la plante (conditions de pouce optimale).
    protected int tauxArrosage = 0; // Niveau d'eau de la plante en pourcentage (par défaut 0%). 
    private const int QUANTITEARROSAGE = 50; // Pourcentage d'eau ajouté à la plante suite à un arrosage.
    protected Etat etat = Etat.BonneSante; // État de santé (par défaut "Bonne santé").
    protected int age = 0; // Âge de la plante en nombre de semaines.
    protected Croissance croissance = Croissance.Semis; // Niveau de croissance de la plante (par défaut "Semis").
    protected int nbProductionsActuel = 0; // Nombre actuel de production de la plante (fruits, légumes...) (par défaut 0).
    protected int nbProductionsMaxPossible = unNbProductionsMaxPossible; // Nombre de production de la plante (fruits, légumes...) maximal possible.
    protected Dictionary<Maladie, int> ProbaMaladies { get; } = []; // Probabilité que la plante attrape une maladie donnée, exprimée en %.
    protected Maladie? maladieActuelle = null; // Maladie dont souffre actuellement la plante.
    protected int toursMalade = 0; // Compteur de tours de jeu où la plante est malade lorsqu'elle l'est.
    protected Coordonnees coordonnees = new(uneCoordX, uneCoordY);  // Coordonnées de la plante.
    protected List<Plante> plantesFilles = []; // Liste des plantes filles de la plante.
    protected Plante? planteParente = null; // Plante parente de la plante.

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
        Accesseur en lecture uniquement des coordonnées d'emplacement de la plante.
    */
    public Coordonnees Coordonnees 
    { 
        get { return coordonnees; }
    }

    /*
        Accesseur en lecture uniquement de la croissance de la plante.
    */
    public Croissance Croissance 
    { 
        get { return croissance; }
    }

    /*
        Accesseur en lecture uniquement de la taille de la plante.
    */
    public int TailleAdulte 
    { 
        get { return tailleAdulte; }
    }
    
    /*
        Accesseur en lecture et écriture de la plante parente de la plante.
    */
    public Plante? PlanteParente
    {
        get { return planteParente; }
        set { planteParente = value; }

    }

    /*
        Accesseur en lecture uniquement de la liste des plantes filles de la plante.
    */
    public List<Plante> PlantesFilles 
    { 
        get { return plantesFilles; }
    }

    /*
        Retourne une description textuelle de la plante.

        return : Chaîne de caractères décrivant l'état actuel de la plante.
    */
    public override string ToString()
    {
        string plante = $"{this.type} {this.symbole} :\n";
        plante += $"  - État : {this.etat}\n";
        if (this.etat == Etat.BonneSante) plante += $"  - Croissance : {this.croissance}\n";
        plante += $"  - Taux d'arrosage : {this.tauxArrosage}%\n";
        plante += $"  - Production : {this.nbProductionsActuel}\n";
        plante += $"  - Taille actuelle : {this.tailleActuelle}\n";

        return plante;
    }

    /*
        Affiche les caractéristiques d'une plante.

        return : Chaîne de caractères décrivant les caractéristiques de la plante.
    */
    public string AfficherCaracteristiques()
    {
        string caracteristiques = $"      - Sol préféré : {this.solPrefere}\n";
        caracteristiques += $"      - Taille adulte : {this.tailleAdulte}\n";
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
        this.tauxArrosage += QUANTITEARROSAGE;
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
            this.Mourir();
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
            this.Mourir();
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
            this.Mourir();
            this.nbProductionsActuel = 0; 
        }
    }

    /*
        Simule la mort d'une plante.
    */
    private void Mourir()
    {
        this.etat = Etat.Morte;
    }

    /*
        Permet à la plante de prendre une taille de plus, soit un emplacement sur le terrain supplémentaire.
        Une plante pousse vers la droite en ligne. Par exemple, une plante de taille 3 placée à la semis aux coordonnées (1,1),
        s'étendra sur les emplacements (1,2) et (1,3) lorsqu'elle devra grandir. Si elle n'a pas la place de prendre sa taille maximale
        (coordonnées hors terrain, emplacement déjà occupé), elle meurt automatiquement.

        param terrain : Terrain sur lequel la plante pousse.

        return : True si la plante a pu s'étendre et prendre sa taille maximale, false sinon (plante morte).
    */
    private bool Grandir(Terrain terrain)
    {
        // On vérifie d'abord si la plante à la place de pousser afin de ne pas créer des plantes filles inutilement.
        for (int i = 1; i < this.tailleAdulte; i++)
        {
            // Si l'emplacement sur lequel doit s'étendre la plante est hors terrain ou n'est pas libre, la plante meurt.
            if (this.Coordonnees.Y + i >= terrain.Emplacements.GetLength(1) || terrain.Emplacements[this.Coordonnees.X, this.Coordonnees.Y + i] != null)
            {
                this.Mourir();
                return false;
            }
        }

        int index = 1;
        while (this.tailleActuelle != this.tailleAdulte)
        {
            Coordonnees coordPlanteFille = new(this.Coordonnees.X, this.Coordonnees.Y + index);
            Plante planteFille = CreerPlanteDepuisType(this.type, coordPlanteFille.X, coordPlanteFille.Y);
            planteFille.planteParente = this;
            this.plantesFilles.Add(planteFille);
            terrain.Emplacements[planteFille.Coordonnees.X, planteFille.Coordonnees.Y] = planteFille;

            index++;
            this.tailleActuelle++;
        }
        return true;
    }

    /*
        Incrémente l'âge de la plante. 
        Si les conditions de croissance sont parfaites, elle grandit plus vite. 
        À certaines étapes, elle change d'état de croissance.
        Lorsque la plante rentre à l'âge adulte, elle grandit et prend sa taille maximale. 
        Si elle n'a pas la place de grandir complètement, elle meurt. 

        param meteo : Météo actuelle (taux d'ensoleillement utilisée).
        param terrain : Terrain sur lequel pousse la plante.

        return : True si la plante est toujours vivante à la fin de sa session de croissance, false sinon.
    */
    private bool GererCroissance(Meteo meteo, Terrain terrain)
    {
        // Conditions parfaites : bon sol, luminosité ±10%, arrosage ±10%
        bool conditionsParfaites =
            this.solPrefere == terrain.TypeSol &&
            Math.Abs(this.besoinsLuminosite - meteo.TauxEnsoleillement) <= 10 &&
            Math.Abs(this.tauxArrosage - this.besoinsEau) <= 0.1 * this.besoinsEau;

        this.age += conditionsParfaites ? 2 : 1;

        // Passage d’étape jusqu'à l'âge adulte (semis < bebe < adolescent < adulte)
        if (this.age % this.vitesseCroissance == 0 && this.croissance != Croissance.Adulte)
        {
            this.croissance += 1;

            if (this.croissance == Croissance.Adulte)
            {
                return this.Grandir(terrain);
            }
        }

        return true;
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

        param terrain : Terrain sur lequel vit la plante.
    */
    private void TenterContamination(Terrain terrain)
    {
        if (this.etat == Etat.Malade)
        {
            this.toursMalade++;
            if (this.toursMalade >= 2)
            {
                this.Mourir();
                this.NbProductionsActuel = 0; // Les productions d'une plante malade sont perdues.
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
            int tirage = new Random().Next(1,101);
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
        param terrain : Terrain sur lequel la plante est cultivée.
    */
    public void MettreAJour(Meteo meteo, Terrain terrain)
    {
        this.AjusterArrosage(meteo);
        this.VerifierTemperature(meteo);
        if (this.croissance == Croissance.Adulte) this.GererVieillissement();
        if (this.etat != Etat.Morte)
        {
            // Tant qu'une plante est malade, elle ne peut ni grandir, ni produire.
            // Une plante peut mourir durant sa session de croissance si elle n'a pas 
            // suffisamment de place pour prendre sa place de taille adulte, à son passage à l'âge adulte.
            if (this.etat == Etat.BonneSante)
                if (this.GererCroissance(meteo, terrain))
                    this.GererProduction();
        }
        // Il n'est pas utile de réduire le taux d'arrosage d'une plante morte ou de tenter de la rendre malade, 
        // puisqu'une plante morte est irrécupérable.
        if (this.etat != Etat.Morte)
        {
            this.ReduireArrosage();
            this.TenterContamination(terrain);
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
        Retarde artificiellement la croissance de la plante de deux semaines.
        Utilisé par certains nuisibles.
    */
    public void RetarderCroissance()
    {
        if (this.age > 0) 
        {
            this.age -= 2;
            this.croissance = (Croissance)(this.age / this.vitesseCroissance);
        }
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
            TypePlante.Cactus => new Cactus(x, y),
            TypePlante.AloeVera => new AloeVera(x, y),
            TypePlante.Dattier => new Dattier(x, y),
            TypePlante.PlanteFeu => new PlanteFeu(x, y),
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
            TypePlante.Cactus => $"{new Cactus().AfficherCaracteristiques()}",
            TypePlante.AloeVera => $"{new AloeVera().AfficherCaracteristiques()}",
            TypePlante.Dattier => $"{new Dattier().AfficherCaracteristiques()}",
            TypePlante.PlanteFeu => $"{new PlanteFeu().AfficherCaracteristiques()}",
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
            TypePlante.Cactus => new Cactus().NbProductionsMaxPossible,
            TypePlante.AloeVera => new AloeVera().NbProductionsMaxPossible,
            TypePlante.Dattier => new Dattier().NbProductionsMaxPossible,
            TypePlante.PlanteFeu => new PlanteFeu().NbProductionsMaxPossible,
            _=> throw new Exception("Type de plante inconnu.")
        };
    }

    /*
        Méthode abstraite pour initialiser les probabilités de maladies spécifiques à la plante.
    */
    protected abstract void InitialiserProbabilitesMaladies();
}