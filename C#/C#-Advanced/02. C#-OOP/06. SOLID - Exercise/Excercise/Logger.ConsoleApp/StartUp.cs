namespace Logger.ConsoleApp
{
    using Logger.ConsoleApp.Core;
    using Logger.ConsoleApp.Core.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();


            //var simpleLayout = new SimpleLayout();
            //var myCustomXmlLayout = new XmlLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);

            //var file = new LogFile("log.xml", "../../../Logs");
            //var fileAppender = new FileAppender(myCustomXmlLayout, file);
             
            //var logger = new Logger.Core.Logging.Logger(consoleAppender, fileAppender);
            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

        }
    }
}