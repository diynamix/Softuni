namespace FastFood.Web.ViewModels.Orders
{
    using System.Collections.Generic;

    public class CreateOrderViewModel
    {
        //public CreateOrderViewModel()
        //{
        //    Items = new List<string>();
        //    Employees = new List<string>();
        //}

        public List<string> Items { get; set; } = null!;

        public List<string> Employees { get; set; } = null!;
    }
}
