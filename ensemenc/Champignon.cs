/*
    Représente une plante spécifique : Champignon.
    Hérite de la classe Plante et initialise ses caractéristiques propres.
*/
public class Champignon : Plante
{
    /*
        Constructeur de la classe Champignon.
    */
    public Champignon(
        string unSymbole = "🍄",
        TypePlante unType = TypePlante.Champignon, 
        int uneTaille = 1, 
        int desBesoinsEau = 80, 
        int desBesoinsLuminosite = 20, 
        int uneTempMin = 5, 
        int uneTempMax = 20, 
        int uneVitesseCroissance = 2, 
        int uneEsperanceVie = 5, 
        TypeSol unSolPrefere = TypeSol.Humifere, 
        int unNbProductionsMaxPossible = 1) : base(unSymbole, unType, uneTaille, desBesoinsEau, desBesoinsLuminosite, uneTempMin, uneTempMax, uneVitesseCroissance, uneEsperanceVie, unSolPrefere, unNbProductionsMaxPossible)
    {
    }
}