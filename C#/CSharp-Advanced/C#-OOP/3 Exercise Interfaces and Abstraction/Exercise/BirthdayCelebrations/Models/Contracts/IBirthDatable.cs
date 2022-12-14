namespace BirthdayCelebrations.Models.Contracts
{
    public interface IBirthDatable
    {
        string Name { get; }
        string BirthDate { get; }

        bool CheckYear(string year);
    }
}
