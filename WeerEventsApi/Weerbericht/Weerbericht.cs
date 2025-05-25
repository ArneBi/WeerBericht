using WeerEventsApi.Steden;
using WeerEventsApi.Facade.Dto;

namespace WeerEventsApi.WeerBericht
{
    public class Weerbericht
    {
        public Weerbericht(DateTime moment, string inhoud)
        {
            Moment = moment;
            Inhoud = inhoud;
        }

        public DateTime Moment { get; set; }
        public string Inhoud { get; set; }


    }
}
