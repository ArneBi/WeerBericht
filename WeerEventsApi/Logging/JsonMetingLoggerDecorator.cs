using System.Text.Json;
using WeerEventsApi.Weerstations;

namespace WeerEventsApi.Logging
{
    public class JsonMetingLoggerDecorator : MetingLoggerDecorator
    {
        public JsonMetingLoggerDecorator(IMetingLogger logger) : base(logger) { }

        public override void Log(Meting meting)
        {


            var jsonObject = new
            {
                meting.Moment,
                meting.Waarde,
                Eenheid = GetEenheidString(meting.Eenheid),
                Locatie = new
                {
                    meting.Locatie.Naam,
                    meting.Locatie.Beschrijving,
                    meting.Locatie.GekendVoor
                }
            };

            var jsonContent = JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.AppendAllText("C:\\Users\\School\\Downloads\\WeerStart\\WeerStart\\WeerEventsApi\\log.json", jsonContent + Environment.NewLine);
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
