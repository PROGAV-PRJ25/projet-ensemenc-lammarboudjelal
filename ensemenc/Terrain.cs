/*
    Représente un terrain cultivable.
    Un terrain possède un nom, un type de sol, et un espace 5x5 pour planter des plantes.
*/
public class Terrain(string unNom, TypeSol unTypeSol)
{
    private string nom = unNom; // Nom du terrain.
    private TypeSol typeSol = unTypeSol; // Type de sol (humifère, argileux, sableux...).
    private Plante [,] plantes = new Plante [5, 5]; // Grille de 5x5 représentant les emplacements de plantes.
    public Plante [,]? Plantes {get;} // Accesseur en lecture uniquement de la grille représentant les emplacements de plantes.
}