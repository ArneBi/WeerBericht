using WeerEventsApi.Steden;

namespace WeerEventsApi.Weerstations.Factories
{
    public class WeerstationFactory : IWeerstationFactory
    {
        private static readonly Random _random = new Random();

        public IEnumerable<Weerstation> MaakWillekeurigeStations(List<Stad> steden)
        {
           List<Weerstation> stationlijst = new List<Weerstation>();
            var stationTypes = new Func<Stad, Weerstation>[]
            {
            stad => new LuchtdrukStation(stad),
            stad => new NeerslagStation(stad),
            stad => new TemperatuurStation(stad),
            stad => new WindStation(stad)
            };

            // Create 12 random stations
            for (int i = 0; i < 12; i++)
            {
                var randomStad = steden[_random.Next(steden.Count)];
                var randomType = stationTypes[_random.Next(stationTypes.Length)];
                stationlijst.Add(randomType(randomStad));
            }
            IEnumerable<Weerstation> stations = stationlijst;

            return stations;
        }
    }
}
