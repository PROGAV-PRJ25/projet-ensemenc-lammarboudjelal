/*
    Représente une plante spécifique : Marguerite.
    Hérite de la classe Plante et initialise ses caractéristiques propres.
*/
public class Marguerite(
    string unSymbole = "🌼",
    TypePlante unType = TypePlante.Marguerite,
    int uneTaille = 1,
    int desBesoinsEau = 40,
    int desBesoinsLuminosite = 90,
    int uneTempMin = 12,
    int uneTempMax = 28,
    int uneVitesseCroissance = 2,
    int uneEsperanceVie = 6,
    TypeSol unSolPrefere = TypeSol.Humifere,
    int unNbProductionsMaxPossible = 1) : Plante(unSymbole, unType, uneTaille, desBesoinsEau, desBesoinsLuminosite, uneTempMin, uneTempMax, uneVitesseCroissance, uneEsperanceVie, unSolPrefere, unNbProductionsMaxPossible)
{
}