/*
    Représente une situation météorologique avec température, ensoleillement et pluie.
*/
public class Meteo
{
    private int temperature; // Température en degrés Celsius.
    private int tauxEnsoleillement; // Taux d'ensoleillement en pourcentage.
    private int tauxPluie; // Taux de précipitations en pourcentage.

    /*
        Constructeur d'une météo.

        param uneTemperature : Température en degrés Celsius.
        param unTauxEnsoleillement : Pourcentage d'ensoleillement.
        param unTauxPluie : Pourcentage de pluie.
    */
    public Meteo(int uneTemperature, int unTauxEnsoleillement, int unTauxPluie)
    {
        this.temperature = uneTemperature;
        this.tauxEnsoleillement = unTauxEnsoleillement;
        this.tauxPluie = unTauxPluie;
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