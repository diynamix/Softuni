namespace SoftUniBazar.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Models.Ad;
    using Models.Category;
    using Services.Contracts;

    public class AdController : BaseController
    {
        private readonly IAdService adService;
        private readonly ICategoryService categoryService;

        public AdController(IAdService adService,
            ICategoryService categoryService)
        {
            this.adService = adService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<AdAllViewModel> model = await adService.GetAllAdsAsync();

            return View(model);
        }

        public async Task<IActionResult> Cart()
        {
            IEnumerable<AdAllViewModel> model = await adService.GetAllAdsInCartByUserIdAsync(GetUserId()!);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ICollection<CategoryAllDataModel> allCategories = await categoryService.GetAllCategoriesAsync();

            AdFormModel formModel = new AdFormModel()
            {
                Categories = allCategories,
            };

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                ICollection<CategoryAllDataModel> allCategories = await categoryService.GetAllCategoriesAsync();

                formModel.Categories = allCategories;

                return View(formModel);
            }

            try
            {
                await adService.CreateAsync(formModel, GetUserId()!);
            }
            catch (Exception)
            {
                return RedirectToAction("All");
            }

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            string userId = GetUserId()!;

            bool adExists = await adService.ExistsByIdAsync(id);

            if (!adExists)
            {
                return RedirectToAction("All");
            }

            bool isUserCreator = await adService.IsUserOwnerAsync(userId, id);

            if (!isUserCreator)
            {
                return RedirectToAction("All");
            }

            AdFormModel formModel = await adService.GetAdForEditAsync(id);

            ICollection<CategoryAllDataModel> allCategories = await categoryService.GetAllCategoriesAsync();

            formModel.Categories = allCategories;

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdFormModel formModel, int id)
        {
            string userId = GetUserId()!;

            bool adExists = await adService.ExistsByIdAsync(id);

            if (!adExists)
            {
                return RedirectToAction("All");
            }

            bool isUserCreator = await adService.IsUserOwnerAsync(userId, id);

            if (!isUserCreator)
            {
                return RedirectToAction("All");
            }

            if (!ModelState.IsValid)
            {
                ICollection<CategoryAllDataModel> allCategories = await categoryService.GetAllCategoriesAsync();

                formModel.Categories = allCategories;

                return View(formModel);
            }

            try
            {
                await adService.EditByIdAsync(formModel, id);
            }
            catch (Exception)
            {
                return RedirectToAction("All");
            }

            return RedirectToAction("All");
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            string userId = GetUserId()!;

            bool adExists = await adService.ExistsByIdAsync(id);

            if (!adExists)
            {
                return RedirectToAction("All");
            }

            bool isAdded = await adService.IsAlreadyAddedAsync(userId, id);

            if (isAdded)
            {
                return RedirectToAction("All");
            }

            bool isUserOwner = await adService.IsUserOwnerAsync(userId, id);

            if (isUserOwner)
            {
                return RedirectToAction("All");
            }

            try
            {
                await adService.AddToCartAsync(userId, id);
            }
            catch (Exception)
            {
                return RedirectToAction("All");
            }

            return RedirectToAction("Cart");
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            string userId = GetUserId()!;

            bool adExists = await adService.ExistsByIdAsync(id);

            if (!adExists)
            {
                return RedirectToAction("All");
            }

            bool isAdded = await adService.IsAlreadyAddedAsync(userId, id);

            if (!isAdded)
            {
                return RedirectToAction("All");
            }

            bool isUserOwner = await adService.IsUserOwnerAsync(userId, id);

            if (isUserOwner)
            {
                return RedirectToAction("All");
            }

            try
            {
                await adService.RemoveFromCartAsync(userId, id);
            }
            catch (Exception)
            {
                return RedirectToAction("Cart");
            }

            return RedirectToAction("All");
        }
    }
}
