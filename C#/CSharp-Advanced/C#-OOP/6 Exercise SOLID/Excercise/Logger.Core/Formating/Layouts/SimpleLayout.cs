namespace Logger.Core.Formating.Layouts
{
    using Interfaces;
    using Logger.Core.Formating.Layouts.Interfaces;

    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
