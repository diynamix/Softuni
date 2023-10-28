namespace SoftUniBazar.Services
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using Data;
    using Data.Models;
    using Models.Ad;

    public class AdService : IAdService
    {
        private readonly BazarDbContext dbContext;

        public AdService(BazarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddToCartAsync(string userId, int adId)
        {
            AdBuyer adBuyer = new AdBuyer()
            {
                BuyerId = userId,
                AdId = adId,
            };

            await dbContext.AdBuyers.AddAsync(adBuyer);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(AdFormModel formModel, string userId)
        {
            Ad ad = new Ad()
            {
                Name = formModel.Name,
                Description = formModel.Description,
                ImageUrl = formModel.ImageUrl,
                CreatedOn = DateTime.Now,
                Price = formModel.Price,
                CategoryId = formModel.CategoryId,
                OwnerId = userId,
            };

            await dbContext.Ads.AddAsync(ad);
            await dbContext.SaveChangesAsync();
        }

        public async Task EditByIdAsync(AdFormModel formModel, int adId)
        {
            Ad? ad = await dbContext.Ads
                .FirstOrDefaultAsync(a => a.Id == adId);

            if (ad != null)
            {
                ad.Name = formModel.Name;
                ad.Description = formModel.Description;
                ad.ImageUrl = formModel.ImageUrl;
                ad.Price = formModel.Price;
                ad.CategoryId = formModel.CategoryId;

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsByIdAsync(int adId)
        {
            return await dbContext.Ads.AnyAsync(a => a.Id == adId);
        }

        public async Task<AdFormModel> GetAdForEditAsync(int adId)
        {
            Ad ad = await dbContext.Ads
            .AsNoTracking()
            .FirstAsync(e => e.Id == adId);

            return new AdFormModel()
            {
                Name = ad.Name,
                Description = ad.Description,
                ImageUrl = ad.ImageUrl,
                Price = ad.Price,
                CategoryId = ad.CategoryId,
            };
        }

        public async Task<IEnumerable<AdAllViewModel>> GetAllAdsAsync()
        {
            return await dbContext.Ads
                .Include(a => a.Owner)
                .Include(a => a.Category)
                .AsNoTracking()
                .Select(a => new AdAllViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    ImageUrl = a.ImageUrl,
                    CreatedOn = a.CreatedOn.ToString("dd-MM-yyyy H:mm"),
                    Category = a.Category.Name,
                    Description = a.Description,
                    Price = a.Price.ToString(),
                    Owner = a.Owner.UserName,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AdAllViewModel>> GetAllAdsInCartByUserIdAsync(string userId)
        {
            return await dbContext.AdBuyers
                .Include(ab => ab.Ad)
                .ThenInclude(a => a.Category)
                .Where(a => a.BuyerId == userId)
                .AsNoTracking()
                .Select(ab => new AdAllViewModel()
                {
                    Id = ab.Ad.Id,
                    Name = ab.Ad.Name,
                    ImageUrl = ab.Ad.ImageUrl,
                    CreatedOn = ab.Ad.CreatedOn.ToString("dd-MM-yyyy H:mm"),
                    Category = ab.Ad.Category.Name,
                    Description = ab.Ad.Description,
                    Price = ab.Ad.Price.ToString(),
                    Owner = ab.Ad.Owner.UserName,
                })
                .ToListAsync();
        }

        public async Task<bool> IsAlreadyAddedAsync(string userId, int adId)
        {
            return await dbContext.AdBuyers
                .AnyAsync(ab => ab.BuyerId == userId && ab.AdId == adId);
        }

        public async Task<bool> IsUserOwnerAsync(string userId, int adId)
        {
            return await dbContext.Ads
                .AnyAsync(a => a.OwnerId == userId && a.Id == adId);
        }

        public async Task RemoveFromCartAsync(string userId, int adId)
        {
            AdBuyer? adBuyer = await dbContext.AdBuyers
                .FirstOrDefaultAsync(ab => ab.BuyerId == userId && ab.AdId == adId);

            if (adBuyer != null)
            {
                dbContext.AdBuyers.Remove(adBuyer);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
