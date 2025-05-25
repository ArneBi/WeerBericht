using System.Text.Json;
using WeerEventsApi.Weerstations;




namespace WeerEventsApi.Logging
{
    public class MetingLogger : IMetingLogger
    {
        public MetingLoggerDecorator JsonDecorator { get; set; }
        public MetingLoggerDecorator XmlDecorator { get; set; }
        public void Log(Meting meting)
        {
           
            if(JsonDecorator != null)
            {
                JsonDecorator.Log(meting);
            }
            if(XmlDecorator != null)
            {
                XmlDecorator.Log(meting);
            }
            if(XmlDecorator == null && JsonDecorator == null)
            {
                Console.WriteLine($"Meting: {meting.Waarde} {GetEenheidString(meting.Eenheid)} in {meting.Locatie.Naam} op {meting.Moment}");
            }
        }

        private string GetEenheidString(Eenheid eenheid)
        {
            return eenheid switch
            {
                Eenheid.KilometerPerUur => "kmh",
                Eenheid.MillimeterPerVierkanteMeterPerUur => "mm/m²/h",
                Eenheid.GradenCelsius => "°C",
                Eenheid.HectoPascal => "hPa",
                _ => eenheid.ToString()
            };
        }
    }



    

   
}
