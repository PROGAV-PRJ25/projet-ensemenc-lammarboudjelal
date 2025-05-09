/*
    Représente une plante spécifique : Tomate.
    Hérite de la classe Plante et initialise ses caractéristiques propres.
*/
public class Tomate : Plante
{
    /*
        Constructeur de la classe Tomate.
    */
    public Tomate(int uneCoordX = 0, int uneCoordY = 0) : base(
        unSymbole: "🍅",
        unType: TypePlante.Tomate,
        uneTaille: 2,
        desBesoinsEau: 70,
        desBesoinsLuminosite: 80,
        uneTempMin: 10,
        uneTempMax: 30,
        uneVitesseCroissance: 4,
        uneEsperanceVie: 12,
        unSolPrefere: TypeSol.Argileux,
        unNbProductionsMaxPossible: 3,
        uneCoordX : uneCoordX,
        uneCoordY : uneCoordY)
    {
        this.InitialiserProbabilitesMaladies(); 
    }

    /*
        Initialise les probabilités de maladies spécifiques à la tomate.
    */
    protected override void InitialiserProbabilitesMaladies()
    {
        ProbaMaladies[Maladie.Mildiou] = 25;
        ProbaMaladies[Maladie.Oidium] = 10;
    }
}