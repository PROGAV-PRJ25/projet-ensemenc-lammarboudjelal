public class Coordonnees(int unX, int unY)
{
    int x = unX;
    int y = unY;

    /*
        Accesseur en lecture uniquement de la coordonnée en x.
    */
    public int X
    {
        get { return x; }
    }

    /*
        Accesseur en lecture uniquement de la coordonnée en y.
    */
    public int Y
    {
        get { return y; }
    }

    /*
        Retourne une description textuelle des coordonnées.

        return : Chaîne de caractères décrivant les coordonnées.
    */
    public override string ToString()
    {
        return $"({this.x + 1},{this.y + 1})";
    }
}