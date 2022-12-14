using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories
{
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
