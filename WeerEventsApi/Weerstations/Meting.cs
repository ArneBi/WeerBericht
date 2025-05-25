using WeerEventsApi.Steden;

namespace WeerEventsApi.Weerstations;

public class Meting
{
    public DateTime Moment { get; set; }
    public double Waarde { get; set; }
    public Eenheid Eenheid { get; set; }
    public Stad Locatie { get; set; }

    public Meting(double waarde, Eenheid eenheid, Stad locatie)
    {
        Moment = DateTime.Now;
        Waarde = waarde;
        Eenheid = eenheid;
        Locatie = locatie;
    }

    public string GetEenheidString(Eenheid eenheid)
    {
        return eenheid switch
        {
            Eenheid.KilometerPerUur => "kmh",
            Eenheid.MillimeterPerVierkanteMeterPerUur => "mm/m²/h",
            Eenheid.GradenCelsius => "°C",
            Eenheid.HectoPascal => "hPa",
            _ => eenheid.ToString()
        };
    }
}
