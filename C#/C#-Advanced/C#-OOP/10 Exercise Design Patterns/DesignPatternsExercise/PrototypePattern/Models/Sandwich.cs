namespace PrototypePattern.Models
{
    public class Sandwich : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }

        // Prototype pattern -> Shallow copy
        public override SandwichPrototype Clone()
        {
            // Info for the user, not part of the prototype pattern
            string ingredientsList = GetIngredientsList();
            Console.WriteLine("Cloning sandwitch with ingredients: {0}", ingredientsList);

            return MemberwiseClone() as SandwichPrototype;
        }

        private string GetIngredientsList() => $"{bread}, {meat}, {cheese}, {veggies}";
    }
}
