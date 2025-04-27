/*
    Représente une plante spécifique : Tomate.
    Hérite de la classe Plante et initialise ses caractéristiques propres.
*/
public class Tomate : Plante
{
    /*
        Constructeur de la classe Tomate.
        Initialise une plante Tomate avec des paramètres prédéfinis (nom, symbole, type, besoins...).
    */
    public Tomate(
        string unNom, 
        string unSymbole = "🍅",
        TypePlante unType = TypePlante.Tomate, 
        int uneTaille = 1, 
        int desBesoinsEau = 60, 
        int desBesoinsLuminosite = 70, 
        int uneTempMin = 10, 
        int uneTempMax = 30, 
        int uneVitesseCroissance = 3, 
        int uneEsperanceVie = 10, 
        TypeSol unSolPrefere = TypeSol.Humifere) : base(unNom, unSymbole, unType, uneTaille, desBesoinsEau, desBesoinsLuminosite, uneTempMin, uneTempMax, uneVitesseCroissance, uneEsperanceVie, unSolPrefere)
    {
    }
}