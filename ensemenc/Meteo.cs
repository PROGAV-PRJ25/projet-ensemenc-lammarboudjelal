/*
    Représente une situation météorologique avec température, ensoleillement et pluie.
*/
public class Meteo(int uneTemperature, int unTauxEnsoleillement, int unTauxPluie)
{
    private int temperature = uneTemperature; // Température en degrés Celsius.
    private int tauxEnsoleillement = unTauxEnsoleillement; // Taux d'ensoleillement en pourcentage.
    private int tauxPluie = unTauxPluie; // Taux de précipitations en pourcentage.

    /*
        Retourne une description textuelle de la météo.

        return : Chaîne de caractères décrivant la météo.
    */
    public override string ToString()
    {
        return $"Température : {this.temperature}°C - Ensoleillement : {this.tauxEnsoleillement}% - Pluie : {this.tauxPluie}%";
    }
}