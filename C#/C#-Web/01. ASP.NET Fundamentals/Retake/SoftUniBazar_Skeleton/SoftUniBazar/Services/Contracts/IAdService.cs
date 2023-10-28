namespace SoftUniBazar.Services.Contracts
{
    using Models.Ad;

    public interface IAdService
    {
        Task<IEnumerable<AdAllViewModel>> GetAllAdsAsync();

        Task<IEnumerable<AdAllViewModel>> GetAllAdsInCartByUserIdAsync(string userId);

        Task AddToCartAsync(string userId, int adId);
        
        Task RemoveFromCartAsync(string userId, int adId);

        Task CreateAsync(AdFormModel formModel, string userId);

        Task<AdFormModel> GetAdForEditAsync(int adId);

        Task EditByIdAsync(AdFormModel formModel, int adId);

        Task<bool> ExistsByIdAsync(int adId);

        Task<bool> IsUserOwnerAsync(string userId, int adId);

        Task<bool> IsAlreadyAddedAsync(string userId, int adId);
    }
}
