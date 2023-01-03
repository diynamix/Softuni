﻿namespace Logger.ConsoleApp.Factories.Interfaces
{
    using Logger.Core.Appenders.Interfaces;
    using Logger.Core.Enums;
    using Logger.Core.Formating.Layouts.Interfaces;
    using Logger.Core.IO.Interfaces;

    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel, ILogFile logFile = null);
    }
}
