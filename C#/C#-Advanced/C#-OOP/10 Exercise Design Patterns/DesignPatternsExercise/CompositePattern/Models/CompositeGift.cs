namespace CompositePattern.Models
{
    using Contracts;

    public class CompositeGift : GiftBase, IGiftOperations
    {
        private ICollection<GiftBase> _gifts;

        public CompositeGift(string name, int price) : base(name, price)
        {
            _gifts = new HashSet<GiftBase>();
        }

        public void Add(GiftBase giftBase)
        {
            _gifts.Add(giftBase);
        }

        public void Remove(GiftBase giftBase)
        {
            _gifts.Remove(giftBase);
        }

        public override int CalculateTotalPrice()
        {
            int total = 0;

            Console.WriteLine($"{name} contains the following products with prices:");

            foreach (GiftBase gift in _gifts)
            {
                total += gift.CalculateTotalPrice();
            }

            return total;
        }
    }
}
