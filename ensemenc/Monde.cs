public abstract class Monde
{
    protected string nom;
    protected List<Meteo> meteosPossibles = [];
    protected List<TypePlante> typesPlanteDisponibles = [];
    protected List<TypeSol> typesSolDisponibles = [];
    public List<TypeSol>? TypesSolDisponibles {get;}

    public Monde(string unNom)
    {
        this.nom = unNom;
    }

    public abstract void AfficherDescription();
    public abstract void AfficherIllustration();
}