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
    public string Illustration { get; set; } = ""; // Illustration propre au monde.

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
        Définit la météo actuelle en sélectionnant aléatoirement une des météos possibles du monde.
    */
    public void DefinirMeteoPrevisionnelle()
    {
        Random rnd = new();
        int indexMeteo = rnd.Next(this.meteosPossibles.Count);
        this.meteoPrevisionnelle = this.meteosPossibles[indexMeteo];
    }

    /*
        Gère une attaque générique d’un nuisible sur les terrains du joueur.

        Cette méthode mutualise la logique des urgences : elle sélectionne une plante cible parmi toutes celles du joueur, affiche une séquence animée, 
        puis permet au joueur de tenter plusieurs actions pour protéger la plante. Si aucune n’aboutit, une action spécifique (passée en paramètre) est appliquée.

        param nomNuisible : Nom affiché du nuisible.
        param messageIntro : Message d’introduction avant l’attaque.
        param terrain1 : Premier terrain du joueur.
        param terrain2 : Deuxième terrain du joueur.
        param conditionCible : Condition pour qu’une plante soit considérée comme une cible valable.
        param actionCible : Méthode spécifique à appeler si le nuisible atteint sa cible. Elle prend en paramètre la plante et le terrain affecté.
        param options : Liste d’actions disponibles pour repousser le nuisible avec leurs probabilités de succès. Si null, on utilise les actions par défaut.
    */
    protected static void GererAttaqueNuisible(
        string nomNuisible,
        string messageIntro,
        Terrain terrain1,
        Terrain terrain2,
        Func<Plante, bool> conditionCible,
        Action<Plante, Terrain> actionCible,
        List<(string description, double probaReussite)>? options = null)
    {
        // Les plantes éligibles (selon la condition de cible) des terrains 1 et 2 sont rassemblées dans une même liste.
        List<(Plante plante, Terrain terrain)> plantesEligibles = [];

        foreach (var plante in terrain1.Plantes)
            if (conditionCible(plante))
                plantesEligibles.Add((plante, terrain1));

        foreach (var plante in terrain2.Plantes)
            if (conditionCible(plante))
                plantesEligibles.Add((plante, terrain2));

        // Si aucune cible valide, l’attaque est sans effet.
        if (plantesEligibles.Count == 0)
        {
            Affichage.AfficherSucces($"\n{nomNuisible} rode... mais il ne trouve rien à nuire !");
            Affichage.AfficherSucces("Il repart sans causer de dégâts.\n");
            Thread.Sleep(2000);
            return;
        }

        // Définition de la plante ciblée par le nuisible.
        var (cible, terrainCible) = plantesEligibles[new Random().Next(plantesEligibles.Count)];

        // Affichage animé de l'arrivée du nuisible.
        Console.Clear();
        Console.WriteLine(messageIntro);
        Thread.Sleep(2000);
        Console.WriteLine($"\n{nomNuisible} approche votre plante {cible.Symbole} en {cible.Coordonnees} !");
        Thread.Sleep(1500);

        // Définition des actions possibles
        List<(string, double)> actions = options ??
        [
            ("Frapper le sol", 0.7),
            ("Vaporiser un jet d'eau", 0.6),
            ("Allumer un répulsif sonore", 0.8)
        ];

        // Actions du joueur pour contrer l'attaque.
        int essaisRestants = 3;
        bool repousse = false;

        while (essaisRestants > 0 && !repousse)
        {
            Console.WriteLine($"\nQue faire ? (Actions restantes : {essaisRestants}/3)\n");

            for (int i = 0; i < actions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {actions[i].Item1} (succès : {actions[i].Item2 * 100:0}%)");
            }
            Console.WriteLine($"{actions.Count + 1}. Ne rien faire\n");

            Affichage.AfficherSaisieUtilisateur("Entrez le numéro de l'action que vous souhaitez réaliser : ");
            string saisie = Console.ReadLine()!;
            double tirage = new Random().NextDouble();

            if (int.TryParse(saisie, out int choix) && choix >= 1 && choix <= actions.Count)
            {
                var action = actions[choix - 1];
                Console.WriteLine($"\n=> Vous tentez : {action.Item1} !");
                repousse = tirage < action.Item2;
            }
            else
            {
                Console.WriteLine("\n=> Vous ne faites rien... Original comme choix...");
                essaisRestants = 0;
            }
            
            Thread.Sleep(1500);

            essaisRestants--;

            if (repousse)
            {
                Affichage.AfficherSucces($"\n{nomNuisible} est repoussé !");
                return;
            }

            if (essaisRestants > 0) 
            {
                Affichage.AfficherAvertissement($"\n{nomNuisible} hésite mais reste menaçant...");
                Thread.Sleep(1500);
            }
        }

        // Si le joueur a échoué, l’action spécifique définie pour ce nuisible est appliquée.
        actionCible(cible, terrainCible); 
    }

    /*
        Méthode abstraite pour afficher la description du monde.
    */
    public abstract void AfficherDescription();

    /*
        Méthode abstraite pour initialiser une illustration ASCII propre au monde.
    */
    public abstract void InitialiserIllustration();

    /*
        Méthode abstraite pour lancer un événement d'urgence spécifique au monde.

        param terrain1 : Premier terrain du joueur.
        param terrain2 : Deuxième terrain du joueur.
    */
    public abstract void LancerUrgence(Terrain terrain1, Terrain terrain2);
}