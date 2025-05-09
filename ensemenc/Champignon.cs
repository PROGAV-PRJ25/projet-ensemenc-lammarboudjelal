/*
    Représente une plante spécifique : Champignon.
    Hérite de la classe Plante et initialise ses caractéristiques propres.
*/
public class Champignon : Plante
{
    /*
        Constructeur de la classe Champignon.
    */
    public Champignon(int uneCoordX = 0, int uneCoordY = 0) : base(
        unSymbole : "🍄",
        unType : TypePlante.Champignon, 
        uneTaille : 1, 
        desBesoinsEau : 80, 
        desBesoinsLuminosite : 20, 
        uneTempMin : 5, 
        uneTempMax : 20, 
        uneVitesseCroissance : 2, 
        uneEsperanceVie : 5, 
        unSolPrefere : TypeSol.Humifere, 
        unNbProductionsMaxPossible : 1,
        uneCoordX : uneCoordX,
        uneCoordY : uneCoordY) 
    {
        this.InitialiserProbabilitesMaladies(); 
    }

    /*
        Initialise les probabilités de maladies spécifiques au champignon.
    */
    protected override void InitialiserProbabilitesMaladies()
    {
        ProbaMaladies[Maladie.Necrose] = 15;
        ProbaMaladies[Maladie.Moisissure] = 20;
    }
}