namespace UniversityCompetition.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Contracts;

    public class SubjectRepository : IRepository<ISubject>
    {
        private ICollection<ISubject> models;

        public SubjectRepository()
        {
            models = new HashSet<ISubject>();
        }

        public IReadOnlyCollection<ISubject> Models => (IReadOnlyCollection<ISubject>)models;

        public void AddModel(ISubject model)
        {
            models.Add(model);
        }

        public ISubject FindById(int id)
        {
            return Models.FirstOrDefault(s => s.Id == id);
        }

        public ISubject FindByName(string name)
        {
            return Models.FirstOrDefault(s => s.Name == name);
        }
    }
}
