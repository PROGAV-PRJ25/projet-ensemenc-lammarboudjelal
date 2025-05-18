/*
    Représente une plante spécifique : Dattier.
    Productive mais lente à pousser, sensible à la chaleur extrême.
    Hérite de la classe Plante et initialise ses caractéristiques propres.
*/
public class Dattier : Plante
{
    /*
        Constructeur de la classe Dattier.
    */
    public Dattier(int uneCoordX = 0, int uneCoordY = 0) : base(
        unSymbole: "🌴",
        unType: TypePlante.Dattier,
        uneTailleAdulte: 3,
        desBesoinsEau: 35,
        desBesoinsLuminosite: 90,
        uneTempMin: 20,
        uneTempMax: 40,
        uneVitesseCroissance: 6,
        uneEsperanceVie: 18,
        unSolPrefere: TypeSol.Sableux,
        unNbProductionsMaxPossible: 10,
        uneCoordX: uneCoordX,
        uneCoordY: uneCoordY)
    {
        this.InitialiserProbabilitesMaladies();
    }

    /*
        Initialise les probabilités de maladies spécifiques au dattier.
    */
    protected override void InitialiserProbabilitesMaladies()
    {
        ProbaMaladies[Maladie.Fusariose] = 20;
        ProbaMaladies[Maladie.Mildiou] = 10;
    }
}
