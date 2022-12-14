namespace Logger.Core.Formating
{
    using Interfaces;
    using Layouts.Interfaces;
    using Models.Intrfaces;

    public class MessagesFormater : IFormater
    {
        public string Format(IMessage message, ILayout layout)
        {
            return String.Format(layout.Format, message.DateTime, message.ReportLevel.ToString(), message.MessageText);
        }
    }
}
