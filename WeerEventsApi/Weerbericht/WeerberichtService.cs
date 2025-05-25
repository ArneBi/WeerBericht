using WeerEventsApi.Facade.Controllers;
using WeerEventsApi.Steden;
using WeerEventsApi.Weerstations;
using WeerEventsApi.Facade.Dto;
using System.Collections.Generic;

namespace WeerEventsApi.WeerBericht
{
    public class WeerberichtService : IWeerberichtService
    {
        public readonly IDomeinController _controller;

        public WeerberichtService(DomeinController controller)
        {
            _controller = controller;
        }
        public IEnumerable<MetingDto> VerwerkMetingen()
        {
           IEnumerable<MetingDto> metingen =  _controller.GeefMetingen();
            return metingen;
        }

        public Weerbericht GeefWeerbericht()
        {
            Thread.Sleep(5000);
            IEnumerable<MetingDto> metingen = VerwerkMetingen();
            Random random = new Random();
            int randomNumber = random.Next(0, 2); // 33% kans op goed weer want belgie is vaker slecht dan goed
            bool GoedWeer = (randomNumber == 0);
            string weer = "";
            if (GoedWeer) { weer = "goed"; } else { weer = "slecht"; }
            string inhoud = $" op basis van {metingen.Count()} metingen kan ik concluderen dat het {weer} weer gaat zijn vandaag";
            Weerbericht weerbericht = new(DateTime.Now, inhoud);



            return weerbericht;
        }
    }
}