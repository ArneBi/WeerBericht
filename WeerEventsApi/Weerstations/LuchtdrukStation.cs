using WeerEventsApi.Steden;

namespace WeerEventsApi.Weerstations
{
    public class LuchtdrukStation : Weerstation
    {
        private static readonly Random _random = new Random();

        public LuchtdrukStation(Stad locatie) : base(locatie) { }

        public override void DoeMetingAsync()
        {
            var waarde = _random.Next(980, 1050); // Realistic pressure range in hPa
            var meting = new Meting(waarde, Eenheid.HectoPascal, Locatie);
            VoegMetingToe(meting);
            _logger.Log(meting);
        }
    }
}
