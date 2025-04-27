/*
    Représente un terrain cultivable.
    Un terrain possède un nom, un type de sol, et un espace 5x5 pour planter des plantes.
*/
public class Terrain
{
    private string nom; // Nom du terrain.
    private TypeSol typeSol; // Type de sol (humifère, argileux, sableux...).
    private Plante [,] plante = new Plante [5, 5]; // Grille de 5x5 représentant les emplacements de plantes.

    /*
        Constructeur de la classe Terrain.

        param unNom : Nom du terrain.
        param unTypeSol : Type de sol.
    */
    public Terrain(string unNom, TypeSol unTypeSol)
    {
        this.nom = unNom;
        this.typeSol = unTypeSol;
    }
}