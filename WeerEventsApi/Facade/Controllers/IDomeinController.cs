using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Weerstations;

namespace WeerEventsApi.Facade.Controllers;

public interface IDomeinController
{
    IEnumerable<StadDto> GeefSteden();
    
    IEnumerable<Weerstation> GeefWeerstations();

    IEnumerable<MetingDto> GeefMetingen();
    
    void DoeMetingen();
    
    WeerBerichtDto GeefWeerbericht();
}