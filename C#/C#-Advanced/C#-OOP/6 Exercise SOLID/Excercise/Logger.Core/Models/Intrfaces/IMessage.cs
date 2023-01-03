namespace Logger.Core.Models.Intrfaces
{
    using Enums;

    public interface IMessage
    {
        string MessageText { get; }
        string DateTime { get; }
        ReportLevel ReportLevel { get; }
    }
}
