namespace Logger.ConsoleApp.Factories.Interfaces
{
    using Logger.Core.Formating.Layouts.Interfaces;

    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
