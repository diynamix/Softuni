namespace Logger.ConsoleApp.Core
{
    using Interfaces;
    using Factories;
    using Factories.Interfaces;
    using Logger.Core.Appenders.Interfaces;
    using Logger.Core.Enums;
    using Logger.Core.Formating.Layouts.Interfaces;
    using Logger.Core.IO;
    using Logger.Core.IO.Interfaces;
    using Logger.Core.Logging.Interfaces;

    public class Engine : IEngine
    {
        private readonly ICollection<IAppender> appenders;
        private ILogger logger;

        private readonly ILayoutFactory layoutFactory;
        private readonly IAppenderFactory appenderFactory;

        public Engine()
        {
            appenders = new HashSet<IAppender>();

            layoutFactory = new LayoutFactory();
            appenderFactory = new AppenderFactory();
        }

        public void Run()
        {
            CreateAppenders();

            logger = new Logger.Core.Logging.Logger(appenders);

            LogMessages();
        }

        private void CreateAppenders()
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    string[] appenderArgs = Console.ReadLine().Split();
                    string appenderType = appenderArgs[0];
                    string layoutType = appenderArgs[1];

                    ILayout layout = layoutFactory.CreateLayout(layoutType);
                    ReportLevel reportLevel = ReportLevel.Info;
                    if (appenderArgs.Length == 3)
                    {
                        bool isReportLevelValid = Enum.TryParse<ReportLevel>(appenderArgs[2], true, out reportLevel);
                        if (!isReportLevelValid)
                        {
                            throw new InvalidOperationException("Report level is not valid!");
                        }
                    }

                    IAppender appender;
                    if (appenderType == "FileAppender")
                    {
                        ILogFile logFile = new LogFile("log.xml", "../../../Logs");
                        appender = appenderFactory.CreateAppender(appenderType, layout, reportLevel, logFile);
                    }
                    else
                    {
                        appender = appenderFactory.CreateAppender(appenderType, layout, reportLevel);
                    }

                    appenders.Add(appender);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void LogMessages()
        {
            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split("|");
                string reportLevelStr = cmdArgs[0];
                string dateTime = cmdArgs[1];
                string message = cmdArgs[2];

                try
                {
                    if (reportLevelStr == "INFO")
                    {
                        logger.Info(dateTime, message);
                    }
                    else if (reportLevelStr == "WARNING")
                    {
                        logger.Warning(dateTime, message);
                    }
                    else if (reportLevelStr == "ERROR")
                    {
                        logger.Error(dateTime, message);
                    }
                    else if (reportLevelStr == "CRITICAL")
                    {
                        logger.Critical(dateTime, message);
                    }
                    else if (reportLevelStr == "FATAL")
                    {
                        logger.Fatal(dateTime, message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
