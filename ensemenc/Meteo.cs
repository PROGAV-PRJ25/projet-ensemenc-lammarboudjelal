/*
    Représente une situation météorologique avec température, ensoleillement et pluie.
*/
public class Meteo(int uneTemperature, int unTauxEnsoleillement, int unTauxPluie)
{
    private readonly int temperature = uneTemperature; // Température en degrés Celsius.
    private readonly int tauxEnsoleillement = unTauxEnsoleillement; // Taux d'ensoleillement en pourcentage.
    private readonly int tauxPluie = unTauxPluie; // Taux de précipitation en pourcentage.

    /*
        Accesseur en lecture uniquement de la température.
    */
    public int Temperature
    {
        get { return temperature; }
    }

    /*
        Accesseur en lecture uniquement du taux d'ensoleillement.
    */
    public int TauxEnsoleillement
    {
        get { return tauxEnsoleillement; }
    }

    /*
        Accesseur en lecture uniquement du taux de précipitation.
    */
    public int TauxPluie
    {
        get { return tauxPluie; }
    }

    /*
        Retourne une description textuelle de la météo.

        return : Chaîne de caractères décrivant la météo.
    */
    public override string ToString()
    {
        return $"Température : {this.temperature}°C - Ensoleillement : {this.tauxEnsoleillement}% - Pluie : {this.tauxPluie}%";
    }
}