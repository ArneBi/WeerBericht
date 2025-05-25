using WeerEventsApi.Steden;
using WeerEventsApi.Weerstations;

namespace WeerEventsApi.Facade.Dto;

public class MetingDto
{

        public DateTime Moment { get; set; }
        public double Waarde { get; set; }
        public string Eenheid { get; set; }
        public Stad Locatie { get; set; }

}