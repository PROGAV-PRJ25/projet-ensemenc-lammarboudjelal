/*
    Représente une plante spécifique : Cactus.
    Très résistante à la chaleur mais sensible aux maladies racinaires.
    Hérite de la classe Plante et initialise ses caractéristiques propres.
*/
public class Cactus : Plante
{
    /*
        Constructeur de la classe Cactus.
    */
    public Cactus(int uneCoordX = 0, int uneCoordY = 0) : base(
        unSymbole: "🌵",
        unType: TypePlante.Cactus,
        uneTailleAdulte: 1,
        desBesoinsEau: 20,
        desBesoinsLuminosite: 95,
        uneTempMin: 20,
        uneTempMax: 45,
        uneVitesseCroissance: 2,
        uneEsperanceVie: 14,
        unSolPrefere: TypeSol.Sableux,
        unNbProductionsMaxPossible: 1,
        uneCoordX: uneCoordX,
        uneCoordY: uneCoordY)
    {
        this.InitialiserProbabilitesMaladies();
    }

    /*
        Initialise les probabilités de maladies spécifiques au cactus.
    */
    protected override void InitialiserProbabilitesMaladies()
    {
        ProbaMaladies[Maladie.Fusariose] = 20; 
        ProbaMaladies[Maladie.CarenceEnFer] = 10;
    }
}
