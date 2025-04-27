public class Terrain
{
    private string nom;
    private TypeSol typeSol;
    private Plante [,] plante = new Plante [5, 5];

    public Terrain(string unNom, TypeSol unTypeSol)
    {
        this.nom = unNom;
        this.typeSol = unTypeSol;
    }
}