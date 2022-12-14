namespace Logger.Core.Formating.Interfaces
{
    using Layouts.Interfaces;
    using Models.Intrfaces;

    public interface IFormater
    {
        string Format(IMessage message, ILayout layout);
    }
}
