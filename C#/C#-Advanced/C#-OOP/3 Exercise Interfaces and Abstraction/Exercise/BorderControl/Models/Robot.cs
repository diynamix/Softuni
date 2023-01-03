namespace BorderControl.Models
{
    using Contracts;

    internal class Robot : Creature
    {
        public Robot(string model, string id) : base(id)
        {
            Model = model;
        }

        public string Model { get; }
    }
}
