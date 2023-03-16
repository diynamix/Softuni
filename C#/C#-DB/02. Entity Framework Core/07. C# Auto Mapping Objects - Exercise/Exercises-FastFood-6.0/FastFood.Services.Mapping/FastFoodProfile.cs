namespace FastFood.Services.Mapping
{
    using System.Globalization;

    using AutoMapper;

    using Models;
    using Web.ViewModels.Categories;
    using Web.ViewModels.Employees;
    using Web.ViewModels.Items;
    using Web.ViewModels.Orders;
    using Web.ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            // Categories ------------------------------------------------------------

            CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.CategoryName));
            // d - destination; opt - options; src - source
            // Member "Name" in destination "Category" to be mapped from source "CreateCategoryInputModel.CategoryName"

            CreateMap<Category, CategoryAllViewModel>();
            // In both "Category" and "CategoryAllViewModel" the property is called "Name".
            // They will be mapped successuly, without any additional writing here.


            // Employees -------------------------------------------------------------

            CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(d => d.PositionId, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.PositionName, opt => opt.MapFrom(src => src.Name));

            CreateMap<RegisterEmployeeInputModel, Employee>();

            CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(d => d.Position, opt => opt.MapFrom(src => src.Position.Name));


            // Items -----------------------------------------------------------------

            CreateMap<Category, CreateItemViewModel>()
                .ForMember(d => d.CategoryId, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(src => src.Name));

            CreateMap<CreateItemInputModels, Item>();

            CreateMap<Item, ItemsAllViewModel>()
                .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category.Name));


            // Orders ----------------------------------------------------------------
            CreateMap<CreateOrderInputModel, Order>()
                .ForMember(d => d.DateTime, opt => opt.MapFrom(s => DateTime.Now));
            //CreateMap<CreateOrderInputModel, OrderItem>()
            //    .ForMember(x => x.ItemId, y => y.MapFrom(s => s.ItemId))
            //    .ForMember(x => x.Quantity, y => y.MapFrom(s => s.Quantity));

            CreateMap<Order, OrderAllViewModel>()
                .ForMember(d => d.OrderId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Employee, opt => opt.MapFrom(s => s.Employee.Name))
                .ForMember(d => d.DateTime, opt => opt.MapFrom(s => s.DateTime.ToString("dd.MM.yyyyг. HH:mm:ssч. (dddd)", new CultureInfo("bg-BG"))));


            // Positions -------------------------------------------------------------

            CreateMap<CreatePositionInputModel, Position>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.PositionName));

            CreateMap<Position, PositionsAllViewModel>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
        }
    }
}
