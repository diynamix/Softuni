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

            // Product
            CreateMap<ImportProductDto, Product>();

            CreateMap<Product, ExportProductsInRangeDto>()
                .ForMember(d => d.ProductName, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.ProductPrice, opt => opt.MapFrom(src => src.Price))
                .ForMember(d => d.SellerName, opt => opt.MapFrom(src => $"{src.Seller.FirstName} {src.Seller.LastName}"));

            // Category
            CreateMap<ImportCategoryDto, Category>();

            // CategoryProduct
            CreateMap<ImportCategoryProductDto, CategoryProduct>();
        }
    }
}
