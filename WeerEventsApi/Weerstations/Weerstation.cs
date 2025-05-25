using WeerEventsApi.Logging;
using WeerEventsApi.Logging.Factories;
using WeerEventsApi.Steden;

namespace WeerEventsApi.Weerstations
{
    public abstract class Weerstation : IWeerstation
    {
        public Stad Locatie { get; protected set; }
        public List<Meting> Metingen { get; protected set; }
        public MetingLogger _logger { get; set; }
        public event Action<Meting> NieuweMetingEvent;

        protected Weerstation(Stad locatie)
        {
            Locatie = locatie;
            Metingen = new List<Meting>();
            _logger = MetingLoggerFactory.Create(false, true); // pas deze boolean waarden aan voor json en/of xml decorators
        }

        public List<Meting> GeefMetingen()
        {
            return new List<Meting>(Metingen);
        }

        public abstract void DoeMetingAsync();

        protected void VoegMetingToe(Meting meting)
        {
            Metingen.Add(meting);
            NieuweMetingEvent?.Invoke(meting);
        }
    }
}
