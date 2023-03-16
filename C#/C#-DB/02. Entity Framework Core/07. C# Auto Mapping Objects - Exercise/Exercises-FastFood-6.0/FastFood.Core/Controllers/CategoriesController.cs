namespace FastFood.Web.Controllers
{
    using FastFood.Services.Data.Contracts;
    using Microsoft.AspNetCore.Mvc;

    using Services.Data;
    using ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
                // "Error" - action; "Home" - controller
            }

            await categoryService.CreateAsync(model);

            return RedirectToAction("All");
            // When redirecting to an "Action" in the same controller, there is no need to write the controller name as a second argument.
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<CategoryAllViewModel> categories = await categoryService.GetAllAsync();

            return View(categories.ToList());
        }
    }
}
