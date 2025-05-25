using System.Runtime.CompilerServices;
using WeerEventsApi.Logging;

namespace WeerEventsApi.Logging.Factories;

public static class MetingLoggerFactory
{
    public static MetingLogger Create(bool decorateWithJson, bool decorateWithXml)
    {
        MetingLogger metinglogger = new MetingLogger();
        if(decorateWithJson == true && decorateWithXml == true)
        {
            metinglogger.XmlDecorator = new XmlMetingLoggerDecorator(metinglogger);
            metinglogger.JsonDecorator = new JsonMetingLoggerDecorator(metinglogger);

        }
        else if (decorateWithJson == false)
        {
            metinglogger.XmlDecorator = new XmlMetingLoggerDecorator(metinglogger);
     
        }
        else if(decorateWithXml == false)
        {
            metinglogger.JsonDecorator = new JsonMetingLoggerDecorator(metinglogger);

        }
        return metinglogger;


    }
}