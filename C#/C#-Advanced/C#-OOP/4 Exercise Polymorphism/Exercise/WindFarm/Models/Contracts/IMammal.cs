namespace WindFarm.Models.Contracts
{
    public interface IMammal : IAnimal
    {
        string LivingRegion { get; }
    }
}
