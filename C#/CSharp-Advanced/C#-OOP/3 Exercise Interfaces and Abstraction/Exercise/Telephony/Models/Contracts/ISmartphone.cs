namespace Telephony.Models.Contracts
{
    public interface ISmartphone : IStationaryPhone
    {
        string BrowseUrl(string url);
    }
}
