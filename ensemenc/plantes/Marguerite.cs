/*
    Représente une plante spécifique : Marguerite.
    Hérite de la classe Plante et initialise ses caractéristiques propres.
*/
public class Marguerite : Plante
{
    /*
        Constructeur de la classe Marguerite.
    */
    public Marguerite(int uneCoordX = 0, int uneCoordY = 0) : base(
        unSymbole: "🌼",
        unType: TypePlante.Marguerite,
        uneTailleAdulte: 1,
        desBesoinsEau: 40,
        desBesoinsLuminosite: 90,
        uneTempMin: 12,
        uneTempMax: 28,
        uneVitesseCroissance: 2,
        uneEsperanceVie: 6,
        unSolPrefere: TypeSol.Humifere,
        unNbProductionsMaxPossible: 1,
        uneCoordX : uneCoordX,
        uneCoordY : uneCoordY)
    {
        this.InitialiserProbabilitesMaladies(); 
    }

    /*
        Initialise les probabilités de maladies spécifiques à la marguerite.
    */
    protected override void InitialiserProbabilitesMaladies()
    {
        ProbaMaladies[Maladie.Oidium] = 10;
    }
}