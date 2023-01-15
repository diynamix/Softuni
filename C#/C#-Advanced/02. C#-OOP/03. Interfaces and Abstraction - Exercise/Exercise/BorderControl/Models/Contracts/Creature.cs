namespace BorderControl.Models.Contracts
{
    public abstract class Creature
    {
        public string Id { get; }

        protected Creature(string id)
        {
            Id = id;
        }

        public bool CheckId(string fakeIdEnding)
        {
            return Id.EndsWith(fakeIdEnding);
        }
    }
}
