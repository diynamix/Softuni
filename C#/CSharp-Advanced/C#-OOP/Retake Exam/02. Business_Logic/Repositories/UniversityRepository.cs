namespace UniversityCompetition.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Contracts;

    public class UniversityRepository : IRepository<IUniversity>
    {
        private ICollection<IUniversity> models;

        public UniversityRepository()
        {
            models = new HashSet<IUniversity>();
        }

        public IReadOnlyCollection<IUniversity> Models => (IReadOnlyCollection<IUniversity>)models;

        public void AddModel(IUniversity model)
        {
            models.Add(model);
        }

        public IUniversity FindById(int id)
        {
            return Models.FirstOrDefault(u => u.Id == id);
        }

        public IUniversity FindByName(string name)
        {
            return Models.FirstOrDefault(u => u.Name == name);
        }
    }
}
