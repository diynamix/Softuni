namespace Logger.Core.Appenders
{
    using Enums;
    using Formating;
    using Formating.Interfaces;
    using Formating.Layouts.Interfaces;
    using Interfaces;
    using IO.Interfaces;
    using Models.Intrfaces;

    public class FileAppender : IAppender
    {
        private readonly IFormater formater;

        private FileAppender()
        {
            formater = new MessagesFormater();
        }

        public FileAppender(ILayout layout, ILogFile logFile, ReportLevel reportLevel = 0) : this()
        {
            Layout = layout;
            LogFile = logFile;
            ReportLevel = reportLevel;
        }

        public ILayout Layout { get; private set; }

        public ILogFile LogFile { get; private set; }

        public ReportLevel ReportLevel { get; private set; }

        public void AppendMessage(IMessage message)
        {
            string output = formater.Format(message, Layout);
            LogFile.WriteLine(output);
            File.AppendAllText(LogFile.FullPath, output + Environment.NewLine);
        }
    }
}
