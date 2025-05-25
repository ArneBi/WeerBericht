using WeerEventsApi.Steden;

namespace WeerEventsApi.Weerstations.Factories
{
    public interface IWeerstationFactory
    {
       IEnumerable<Weerstation> MaakWillekeurigeStations(List<Stad> steden);
    }
}
