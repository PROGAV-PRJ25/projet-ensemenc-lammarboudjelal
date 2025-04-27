/*
    Représente une plante spécifique : Tomate.
    Hérite de la classe Plante et initialise ses caractéristiques propres.
*/
public class Tomate(
    string unNom,
    string unSymbole = "🍅",
    TypePlante unType = TypePlante.Tomate,
    int uneTaille = 2,
    int desBesoinsEau = 60,
    int desBesoinsLuminosite = 70,
    int uneTempMin = 10,
    int uneTempMax = 30,
    int uneVitesseCroissance = 3,
    int uneEsperanceVie = 1,
    TypeSol unSolPrefere = TypeSol.Humifere) : Plante(unNom, unSymbole, unType, uneTaille, desBesoinsEau, desBesoinsLuminosite, uneTempMin, uneTempMax, uneVitesseCroissance, uneEsperanceVie, unSolPrefere)
{
}