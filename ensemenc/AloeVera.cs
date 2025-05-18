/*
    Représente une plante spécifique : Aloé Vera.
    Plante médicinale résistante à la sécheresse.
    Hérite de la classe Plante et initialise ses caractéristiques propres.
*/
public class AloeVera : Plante
{
    /*
        Constructeur de la classe AloeVera.
    */
    public AloeVera(int uneCoordX = 0, int uneCoordY = 0) : base(
        unSymbole: "🪴",
        unType: TypePlante.AloeVera,
        uneTailleAdulte: 2,
        desBesoinsEau: 30,
        desBesoinsLuminosite: 85,
        uneTempMin: 15,
        uneTempMax: 35,
        uneVitesseCroissance: 5,
        uneEsperanceVie: 11,
        unSolPrefere: TypeSol.Sableux,
        unNbProductionsMaxPossible: 1,
        uneCoordX: uneCoordX,
        uneCoordY: uneCoordY)
    {
        this.InitialiserProbabilitesMaladies();
    }

    /*
        Initialise les probabilités de maladies spécifiques à l'aloé vera.
    */
    protected override void InitialiserProbabilitesMaladies()
    {
        ProbaMaladies[Maladie.Oidium] = 15;
        ProbaMaladies[Maladie.CarenceEnFer] = 20;
    }
}
