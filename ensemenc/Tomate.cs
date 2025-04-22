public class Tomate : Plante
{
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
        TypeSol unSolPrefere = TypeSol.Terre) : base(unNom, unSymbole, unType, uneTaille, desBesoinsEau, desBesoinsLuminosite, uneTempMin, uneTempMax, uneVitesseCroissance, uneEsperanceVie, unSolPrefere)
    {
    }
}