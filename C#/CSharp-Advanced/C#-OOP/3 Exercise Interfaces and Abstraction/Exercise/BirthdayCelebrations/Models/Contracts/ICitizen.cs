namespace BirthdayCelebrations.Models.Contracts
{
    public interface ICitizen : IBirthDatable
    {
        int Age { get; }
        string Id { get; }
    }
}
