public class Meteo
{
    private int temperature;
    private int tauxEnsoleillement;
    private int tauxPluie;

    public Meteo(int uneTemperature, int unTauxEnsoleillement, int unTauxPluie)
    {
        this.temperature = uneTemperature;
        this.tauxEnsoleillement = unTauxEnsoleillement;
        this.tauxPluie = unTauxPluie;
    }

    public override string ToString()
    {
        return $"Température : {this.temperature}°C - Ensoleillement : {this.tauxEnsoleillement}% - Pluie : {this.tauxPluie}%";
    }
}