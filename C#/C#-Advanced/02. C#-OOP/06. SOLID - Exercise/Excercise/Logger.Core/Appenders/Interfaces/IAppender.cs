namespace Logger.Core.Appenders.Interfaces
{
    using Formating.Layouts.Interfaces;
    using Enums;
    using Models.Intrfaces;

    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; }

        void AppendMessage(IMessage message);
    }
}
