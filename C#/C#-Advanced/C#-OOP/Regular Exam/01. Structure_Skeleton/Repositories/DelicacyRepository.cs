namespace ChristmasPastryShop.Repositories
{
    using System.Collections.Generic;

    using Contracts;
    using Models.Delicacies.Contracts;

    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private  ICollection<IDelicacy> models;

        public DelicacyRepository()
        {
            models = new HashSet<IDelicacy>();
        }

        public IReadOnlyCollection<IDelicacy> Models => (IReadOnlyCollection<IDelicacy>)models;

        public void AddModel(IDelicacy delicacy)
        {
            models.Add(delicacy);
        }
    }
}
