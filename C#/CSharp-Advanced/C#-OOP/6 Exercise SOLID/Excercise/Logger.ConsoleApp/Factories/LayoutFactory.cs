namespace Logger.ConsoleApp.Factories
{
    using Interfaces;
    using Logger.Core.Formating.Layouts.Interfaces;
    using Logger.Core.Formating.Layouts;
    using Logger.ConsoleApp.CustomLayouts;

    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            ILayout layout;
            if (type == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if (type == "XmlLayout")
            {
                layout = new XmlLayout();
            }
            else
            {
                throw new InvalidOperationException("Invalid layout type!");
            }

            return layout;
        }
    }
}
