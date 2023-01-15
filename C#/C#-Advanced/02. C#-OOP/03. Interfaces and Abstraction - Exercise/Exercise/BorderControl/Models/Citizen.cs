namespace BorderControl.Models
{
    using Contracts;

    public class Citizen : Creature
    {
        public Citizen(string name, int age, string id) : base(id)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; }
        public int Age { get; }
    }
}
