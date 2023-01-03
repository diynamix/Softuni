namespace UniversityCompetition.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Contracts;

    public class StudentRepository : IRepository<IStudent>
    {
        private ICollection<IStudent> models;

        public StudentRepository()
        {
            models = new HashSet<IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models => (IReadOnlyCollection<IStudent>)models;

        public void AddModel(IStudent model)
        {
            models.Add(model);
        }

        public IStudent FindById(int id)
        {
            return Models.FirstOrDefault(s => s.Id == id);
        }

        public IStudent FindByName(string name)
        {
            string firstName = name.Split(' ')[0];
            string lastName = name.Split(' ')[1];

            return Models.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }
    }
}
