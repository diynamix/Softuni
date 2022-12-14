﻿namespace Logger.Core.Appenders
{
    using Enums;
    using Formating;
    using Formating.Interfaces;
    using Formating.Layouts.Interfaces;
    using Interfaces;
    using Models.Intrfaces;

    public class ConsoleAppender : IAppender
    {
        private readonly IFormater formater;

        public ConsoleAppender()
        {
            formater = new MessagesFormater();
        }

        public ConsoleAppender(ILayout layout, ReportLevel reportLevel = 0) : this()
        {
            Layout = layout;
            ReportLevel = reportLevel;
        }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; private set; }

        public void AppendMessage(IMessage message)
        {
            string output = formater.Format(message, Layout);
            Console.WriteLine(output);
        }
    }
}
