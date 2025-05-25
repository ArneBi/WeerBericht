using WeerEventsApi.Steden;

namespace WeerEventsApi.Weerstations
{
    public class NeerslagStation : Weerstation
    {
        private static readonly Random _random = new Random();

        public NeerslagStation(Stad locatie) : base(locatie) { }

        public override void DoeMetingAsync()
        {
            var waarde = _random.NextDouble() * 50; // 0-50 mm/m²/h
            var meting = new Meting(waarde, Eenheid.MillimeterPerVierkanteMeterPerUur, Locatie);
            VoegMetingToe(meting);
            _logger.Log(meting);
        }
    }
}
