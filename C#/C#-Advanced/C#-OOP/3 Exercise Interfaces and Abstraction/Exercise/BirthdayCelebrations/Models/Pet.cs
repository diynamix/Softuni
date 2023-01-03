namespace BirthdayCelebrations.Models
{
    using Contracts;

    public class Pet : IBirthDatable
    {
        public Pet(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public string Name { get; private set;  }
        public string BirthDate { get; private set; }

        public bool CheckYear(string year) => BirthDate.EndsWith($"/{year}");
    }
}
