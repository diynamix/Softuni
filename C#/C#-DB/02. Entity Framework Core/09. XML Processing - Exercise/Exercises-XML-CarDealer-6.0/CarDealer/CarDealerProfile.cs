namespace CarDealer
{
    using System.Globalization;

    using AutoMapper;
    using DTOs.Export;
    using DTOs.Import;
    using Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            // Supplier
            CreateMap<ImportSupplierDto, Supplier>();

            CreateMap<Supplier, ExportLocalSupplierDto>()
                .ForMember(d => d.partsCount, opt => opt.MapFrom(s => s.Parts.Count));

            // Part
            CreateMap<ImportPartDto, Part>()
                .ForMember(d => d.SupplierId, opt => opt.MapFrom(s => s.SupplierId.Value));

            CreateMap<Part, ExportCarPartDto>();

            // Car
            //CreateMap<ImportCarDto, Car>()
            //    .ForMember(d => d.PartsCars,
            //        opt => opt.MapFrom(s => s.Parts.Select(p => new PartCar() { PartId = p.PartId })));

            //CreateMap<ImportCarPartDto, PartCar>();
            CreateMap<ImportCarDto, Car>()
                //.ForMember(d => d.PartsCars, opt => opt.Ignore())
                .ForSourceMember(s => s.Parts, opt => opt.DoNotValidate());

            CreateMap<Car, ExportCarDtoElements>();

            CreateMap<Car, ExportBmwCarDto>();

            CreateMap<Car, ExportCarWithPartsDto>()
                .ForMember(d => d.Parts,
                    opt => opt.MapFrom(s => s.PartsCars
                        .Select(pc => pc.Part)
                        .OrderByDescending(p => p.Price)
                        .ToArray()));

            CreateMap<Car, ExportCarDtoAttributes>();

            // Customer
            CreateMap<ImportCustomerDto, Customer>()
                .ForMember(d => d.BirthDate, opt => opt.MapFrom(s => DateTime.Parse(s.BirthDate, CultureInfo.InvariantCulture)));

            CreateMap<Customer, ExportTotalSalesByCustomerDto>()
                .ForMember(d => d.BoughtCars, opt => opt.MapFrom(s => s.Sales.Count))
                .ForMember(d => d.SpentMoney, opt => opt
                    .MapFrom(c => c.IsYoungDriver
                        ? Math.Truncate(c.Sales.SelectMany(s => s.Car.PartsCars.Select(pc => pc.Part.Price)).Sum() * 95) / 100
                        : Math.Truncate(c.Sales.SelectMany(s => s.Car.PartsCars.Select(pc => pc.Part.Price)).Sum() * 100) / 100));

            // Sale
            CreateMap<ImportSaleDto, Sale>()
                .ForMember(d => d.CarId, opt => opt.MapFrom(s => s.CarId.Value));

            CreateMap<Sale, ExportSaleWithDiscountDto>()
                .ForMember(d => d.CustomerName, opt => opt.MapFrom(s => s.Customer.Name))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Car.PartsCars.Select(pc => pc.Part.Price).Sum()))
                //.ForMember(d => d.PriceWithDiscount, opt => opt.MapFrom(s => Math.Round(s.Car.PartsCars.Select(pc => pc.Part.Price).Sum() * (1 - (s.Discount / 100)), 4)));
                .ForMember(d => d.PriceWithDiscount, opt => opt.MapFrom(s => Math.Truncate(s.Car.PartsCars.Sum(p => p.Part.Price) * (100 - s.Discount)) / 100));
            }
    }
}
