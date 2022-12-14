namespace ChristmasPastryShop.Repositories
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Models.Booths.Contracts;

    public class BoothRepository : IRepository<IBooth>
    {
        private ICollection<IBooth> models;

        public BoothRepository()
        {
            models = new HashSet<IBooth>();
        }

        public IReadOnlyCollection<IBooth> Models => (IReadOnlyCollection<IBooth>)models;

        public void AddModel(IBooth booth)
        {
            models.Add(booth);
        }
    }
}
