using WeerEventsApi.Steden;

namespace WeerEventsApi.Weerstations
{
    public interface IWeerstation
    {
        Stad Locatie { get; }
        List<Meting> Metingen { get; }
        event Action<Meting> NieuweMetingEvent;
        List<Meting> GeefMetingen();
        void DoeMetingAsync();
    }
}