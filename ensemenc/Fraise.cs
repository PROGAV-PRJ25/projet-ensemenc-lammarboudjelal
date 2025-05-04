/*
    Représente une plante spécifique : Fraise.
    Hérite de la classe Plante et initialise ses caractéristiques propres.
*/
public class Fraise(
    string unSymbole = "🍓",
    TypePlante unType = TypePlante.Fraise,
    int uneTaille = 1,
    int desBesoinsEau = 60,
    int desBesoinsLuminosite = 85,
    int uneTempMin = 8,
    int uneTempMax = 25,
    int uneVitesseCroissance = 3,
    int uneEsperanceVie = 7,
    TypeSol unSolPrefere = TypeSol.Humifere,
    int unNbProductionsMaxPossible = 4) : Plante(unSymbole, unType, uneTaille, desBesoinsEau, desBesoinsLuminosite, uneTempMin, uneTempMax, uneVitesseCroissance, uneEsperanceVie, unSolPrefere, unNbProductionsMaxPossible)
{
}