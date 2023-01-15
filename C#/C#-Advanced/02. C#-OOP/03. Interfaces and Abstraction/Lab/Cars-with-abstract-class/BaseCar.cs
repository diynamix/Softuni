namespace Cars
{
    public abstract class BaseCar
    {
        protected BaseCar(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model { get; set; }
        public string Color { get; set; }

        public string Start() => "Engine start";

        public string Stop() => "Breaaak!";
    }


    //public interface ICar
    //{
    //    public string Model { get; set; }
    //    public string Color { get; set; }

    //    public string Start();

    //    public string Stop();
    //}
}
