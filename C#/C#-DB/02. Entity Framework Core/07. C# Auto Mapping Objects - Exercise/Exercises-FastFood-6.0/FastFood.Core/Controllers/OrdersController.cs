namespace FastFood.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Data;
    using Services.Data.Contracts;
    using ViewModels.Orders;

    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;
        private readonly FastFoodContext context = new FastFoodContext();

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        //[HttpGet]
        public IActionResult Create()
        {
            var viewOrder = new CreateOrderViewModel
            {
                Items = this.context.Items.Select(x => x.Id).ToList(),
                Employees = this.context.Employees.Select(x => x.Id).ToList(),
            };

            return this.View(viewOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            await orderService.CreateAsync(model);
            return RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<OrderAllViewModel> orders = await orderService.GetAllAsync();

            return View(orders.ToList());
        }
    }
}
