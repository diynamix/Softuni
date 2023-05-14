namespace ProductShop
{
    using AutoMapper;

    using DTOs.Export;
    using DTOs.Import;
    using Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            // User
            CreateMap<ImportUserDto, User>();

            CreateMap<User, ExportUserDto>();
            //.ForMember(d => d.ProductsSold,
            //    opt => opt.MapFrom(s => s.ProductsSold
            //        .Select(p => new ExportSoldProductDto())
            //        .ToArray()));

            // Product
            CreateMap<ImportProductDto, Product>();

            CreateMap<Product, ExportProductInRangeDto>()
                .ForMember(d => d.Buyer, opt => opt.MapFrom(s => s.Buyer.FirstName + " " + s.Buyer.LastName));

            CreateMap<Product, ExportSoldProductDto>();

            // Category
            CreateMap<ImportCategoryDto, Category>();

            // CategoryProduct
            CreateMap<ImportCategoryProductDto, CategoryProduct>();
        }
    }
}
