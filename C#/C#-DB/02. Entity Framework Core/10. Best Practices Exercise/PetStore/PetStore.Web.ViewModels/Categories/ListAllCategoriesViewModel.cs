namespace PetStore.Web.ViewModels.Categories
{
    public class ListAllCategoriesViewModel
    {
        //public ListAllCategoriesViewModel()
        //{
        //    AllCategories = new HashSet<ListCategoryViewModel>();
        //}
        public IEnumerable<ListCategoryViewModel> AllCategories { get; set; }

        public int PageCount { get; set; }

        public int ActivePage { get; set; }
    }
}
