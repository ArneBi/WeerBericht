using WeerEventsApi.Steden;

namespace WeerEventsApi.Weerstations
{
    public class TemperatuurStation : Weerstation
    {
        private static readonly Random _random = new Random();

        public TemperatuurStation(Stad locatie) : base(locatie) { }

        public override void DoeMetingAsync()
        {
            var waarde = _random.Next(-10, 35); // -10°C to 35°C
            var meting = new Meting(waarde, Eenheid.GradenCelsius, Locatie);
            VoegMetingToe(meting);
            _logger.Log(meting);
        }
    }
}