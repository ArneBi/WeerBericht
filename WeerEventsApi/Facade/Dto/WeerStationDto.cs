using WeerEventsApi.Steden;
using WeerEventsApi.Weerstations;

namespace WeerEventsApi.Facade.Dto;

public class WeerStationDto
{
    public Stad Locatie { get; protected set; }
    public List<Meting> Metingen { get; protected set; }
}