using WeerEventsApi.Weerstations;

namespace WeerEventsApi.Logging
{
    public class XmlMetingLoggerDecorator : MetingLoggerDecorator
    {
        public XmlMetingLoggerDecorator(IMetingLogger logger) : base(logger) { }

        public override void Log(Meting meting)
        {

                        var xmlContent = $@"<Meting>
                <Moment>{meting.Moment:dd/MM/yyyy HH:mm:ss}</Moment>
                <Waarde>{meting.Waarde}</Waarde>
                <Eenheid>{GetEenheidString(meting.Eenheid)}</Eenheid>
            </Meting>";

            File.AppendAllText("C:\\Users\\School\\Downloads\\WeerStart\\WeerStart\\WeerEventsApi\\log.xml", xmlContent + Environment.NewLine);
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