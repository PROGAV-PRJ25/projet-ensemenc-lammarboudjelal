/*
    Représente une plante spécifique : Fraise.
    Hérite de la classe Plante et initialise ses caractéristiques propres.
*/
public class Fraise : Plante
{
    /*
        Constructeur de la classe Fraise.
    */
    public Fraise(int uneCoordX = 0, int uneCoordY = 0) : base(
        unSymbole: "🍓",
        unType: TypePlante.Fraise,
        uneTailleAdulte: 1,
        desBesoinsEau: 60,
        desBesoinsLuminosite: 85,
        uneTempMin: 8,
        uneTempMax: 25,
        uneVitesseCroissance: 3,
        uneEsperanceVie: 7,
        unSolPrefere: TypeSol.Humifere,
        unNbProductionsMaxPossible: 4,
        uneCoordX : uneCoordX,
        uneCoordY : uneCoordY)
    {
        this.InitialiserProbabilitesMaladies(); 
    }

    /*
        Initialise les probabilités de maladies spécifiques à la fraise.
    */
    protected override void InitialiserProbabilitesMaladies()
    {
        ProbaMaladies[Maladie.Moisissure] = 20;
        ProbaMaladies[Maladie.Mildiou] = 10;
    }
}