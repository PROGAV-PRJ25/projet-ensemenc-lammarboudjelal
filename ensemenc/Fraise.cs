/*
    Représente une plante spécifique : Fraise.
    Hérite de la classe Plante et initialise ses caractéristiques propres.
*/
public class Fraise : Plante
{
    /*
        Constructeur de la classe Fraise.
    */
    public Fraise(
        string unNom, 
        string unSymbole = "🍓",
        TypePlante unType = TypePlante.Fraise, 
        int uneTaille = 1, 
        int desBesoinsEau = 60, 
        int desBesoinsLuminosite = 85, 
        int uneTempMin = 8, 
        int uneTempMax = 25, 
        int uneVitesseCroissance = 3, 
        int uneEsperanceVie = 1, 
        TypeSol unSolPrefere = TypeSol.Humifere) : base(unNom, unSymbole, unType, uneTaille, desBesoinsEau, desBesoinsLuminosite, uneTempMin, uneTempMax, uneVitesseCroissance, uneEsperanceVie, unSolPrefere)
    {
    }
}