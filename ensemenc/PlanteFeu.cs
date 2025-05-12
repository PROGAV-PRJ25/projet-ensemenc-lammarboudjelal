/*
    Représente une plante spécifique : Plante Feu.
    Peut repousser certains nuisibles, mais dangereuse pour les plantes voisines.
    Hérite de la classe Plante et initialise ses caractéristiques propres.
*/
public class PlanteFeu : Plante
{
    /*
        Constructeur de la classe PlanteFeu.
    */
    public PlanteFeu(int uneCoordX = 0, int uneCoordY = 0) : base(
        unSymbole: "🔥",
        unType: TypePlante.PlanteFeu,
        uneTaille: 2,
        desBesoinsEau: 25,
        desBesoinsLuminosite: 100,
        uneTempMin: 18,
        uneTempMax: 40,
        uneVitesseCroissance: 3,
        uneEsperanceVie: 11,
        unSolPrefere: TypeSol.Sableux,
        unNbProductionsMaxPossible: 1,
        uneCoordX: uneCoordX,
        uneCoordY: uneCoordY)
    {
        this.InitialiserProbabilitesMaladies();
    }

    /*
        Initialise les probabilités de maladies spécifiques à la plante feu.
    */
    protected override void InitialiserProbabilitesMaladies()
    {
        ProbaMaladies[Maladie.Oidium] = 10;
        ProbaMaladies[Maladie.Fusariose] = 15;
    }
}
