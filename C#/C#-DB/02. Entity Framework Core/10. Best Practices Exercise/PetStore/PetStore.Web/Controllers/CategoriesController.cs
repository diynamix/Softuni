namespace PetStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using PetStore.Services.Data;
    using ViewModels.Categories;

    //[Authorize(Roles = "User")]
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
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home", new
                {
                    errorMessage = "There was an error with validation entity!",
                });
            }

            await this.categoryService.CreteAsync(model);

            return this.RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> All(int page)
        {
            IEnumerable<ListCategoryViewModel> allCategories = await this.categoryService.GetAllWithPaginationAsync(page);

            ListAllCategoriesViewModel viewModel = new ListAllCategoriesViewModel()
            {
                AllCategories = allCategories,
                PageCount = (int)Math.Ceiling(allCategories.Count() / 2.0),
                ActivePage = page,
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            bool isValidCategory = await this.categoryService
                .ExistsAsync(id);

            if (!isValidCategory)
            {
                return this.RedirectToAction("All");
            }

            EditCategoryViewModel categoryToEdit = await this.categoryService.GetByIdAndPrepareForEditAsync(id);

            return this.View(categoryToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCategoryViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home", new { errorMessage = "Validation error!" });
            }

            bool isValidCategory = await this.categoryService
                .ExistsAsync(model.Id);

            if (!isValidCategory)
            {
                return this.RedirectToAction("All");
            }

            await this.categoryService.EditCategoryAsync(model);

            return this.RedirectToAction("All");
        }
    }
}
