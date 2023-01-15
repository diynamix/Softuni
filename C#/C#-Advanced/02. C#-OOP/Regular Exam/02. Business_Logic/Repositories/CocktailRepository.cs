namespace ChristmasPastryShop.Repositories
{
    using System.Collections.Generic;

    using Contracts;
    using Models.Cocktails.Contracts;

    public class CocktailRepository : IRepository<ICocktail>
    {
        private ICollection<ICocktail> models;

        public CocktailRepository()
        {
            models = new HashSet<ICocktail>();
        }

        public IReadOnlyCollection<ICocktail> Models => (IReadOnlyCollection<ICocktail>)models;

        public void AddModel(ICocktail cocktail)
        {
            models.Add(cocktail);
        }
    }
}
