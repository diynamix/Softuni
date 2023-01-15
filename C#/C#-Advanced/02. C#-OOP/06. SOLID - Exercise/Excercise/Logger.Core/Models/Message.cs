namespace Logger.Core.Models
{
    using Enums;
    using Exceptions;
    using Intrfaces;
    using Utilities;

    public class Message : IMessage
    {
        private string messageText;
        private string dateTime;

        public Message(string messageText, string dateTime, ReportLevel reportLevel)
        {
            MessageText = messageText;
            DateTime = dateTime;
            ReportLevel= reportLevel;
        }

        public string MessageText
        {
            get { return messageText; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyMessageTextException();
                }
                messageText = value;
            }
        }

        public string DateTime
        {
            get { return dateTime; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyDateTimeException();
                }

                if (DateTimeValidator.IsDateTimeValid(value))
                {
                    throw new InvalidDateTimeFormatException();
                }

                dateTime = value;
            }
        }

        public ReportLevel ReportLevel { get; private set; }
    }
}
