using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Logging;
using WeerEventsApi.Steden.Managers;
using WeerEventsApi.Weerstations;
using System.Text.Json;
using WeerEventsApi.Steden;
using WeerEventsApi.Weerstations.Factories;
using WeerEventsApi.Logging.Factories;
using System.Diagnostics.Eventing.Reader;
using WeerEventsApi.WeerBericht;

namespace WeerEventsApi.Facade.Controllers;

public class DomeinController : IDomeinController
{
    private readonly IStadManager _stadManager;
    private readonly WeerstationFactory _weerstationFactory;
    IEnumerable<Weerstation> _weerstations;
    private readonly IWeerberichtService _weerberichtservice;


    public DomeinController(IStadManager stadManager)
    {
        _stadManager = stadManager;
        _weerstationFactory = new WeerstationFactory();
        _weerstations = _weerstationFactory.MaakWillekeurigeStations(_stadManager.GeefSteden());
        _weerberichtservice = new WeerberichtService(this);
    }

    public IEnumerable<StadDto> GeefSteden()
    {
        return _stadManager.GeefSteden().Select(s => new StadDto
        {
            Naam = s.Naam,
            Beschrijving = s.Beschrijving,
            GekendVoor = s.GekendVoor
        });
    }

    public IEnumerable<Weerstation> GeefWeerstations()
    {
        //TODO
         return _weerstations;
    }


    public IEnumerable<MetingDto> GeefMetingen()
    {
        List<MetingDto> metingenList = new();

        foreach(Weerstation station in _weerstations)
        {
            
            foreach (Meting meting in station.GeefMetingen())
            {
                MetingDto metingDto = new MetingDto();
                metingDto.Waarde = meting.Waarde;
                metingDto.Moment = meting.Moment;
                metingDto.Eenheid = meting.GetEenheidString(meting.Eenheid);
                metingDto.Locatie = meting.Locatie;
                metingenList.Add(metingDto);

            }
            
        }
        IEnumerable<MetingDto> metingen = metingenList;
        return metingen;

    }

    public void DoeMetingen()
    {
        foreach (Weerstation station in GeefWeerstations())
        {
            station.DoeMetingAsync();

        }
    }

    public WeerBerichtDto GeefWeerbericht()
    {
        Weerbericht bericht = _weerberichtservice.GeefWeerbericht();
        WeerBerichtDto weerbericht = new();
        weerbericht.Moment = bericht.Moment;
        weerbericht.Inhoud = bericht.Inhoud;
        return weerbericht;
    }
}