namespace FastFood.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Services.Data;
    using Services.Data.Contracts;
    using ViewModels.Items;

    public class ItemsController : Controller
    {
        private readonly IItemService itemService;

        public ItemsController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<CreateItemViewModel> availableCategories = await itemService.GetAllAvailableCategoriesAsync();

            return View(availableCategories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemInputModels model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            await itemService.CreateAsync(model);
            return RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<ItemsAllViewModel> items = await itemService.GetAllAsync();

            return View(items.ToList());
        }
    }
}
