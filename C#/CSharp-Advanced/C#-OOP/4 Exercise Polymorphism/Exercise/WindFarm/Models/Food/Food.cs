namespace WindFarm.Models.Food
{
    using Contracts;

    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} - {Quantity}";
        }
    }
}
