using WeerEventsApi.Steden.Repositories;

namespace WeerEventsApi.Steden.Managers;

public class StadManager(IStadRepository repository) : IStadManager
{
    public List<Stad> GeefSteden()
    {
        return repository.GetSteden();
    }
}