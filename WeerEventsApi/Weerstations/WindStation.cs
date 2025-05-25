using WeerEventsApi.Steden;

namespace WeerEventsApi.Weerstations
{
    public class WindStation : Weerstation
    {
        private static readonly Random _random = new Random();

        public WindStation(Stad locatie) : base(locatie) { }

        public override void DoeMetingAsync()
        {
            var waarde = _random.NextDouble() * 120; // 0-120 km/h
            var meting = new Meting(waarde, Eenheid.KilometerPerUur, Locatie);
            base.VoegMetingToe(meting);
            _logger.Log(meting);
        }
    }
}
