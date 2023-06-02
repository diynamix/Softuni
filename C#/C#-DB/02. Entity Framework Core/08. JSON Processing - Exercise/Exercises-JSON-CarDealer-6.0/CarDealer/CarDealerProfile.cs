namespace CarDealer
{
    using AutoMapper;

    using DTOs.Export;
    using DTOs.Import;
    using Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            // Cars
            CreateMap<Car, ExportCarsFromMakeToyotaDto>();

            // Suppliers
            CreateMap<ImportSupplierDto, Supplier>();

            // Parts
            CreateMap<ImportPartDto, Part>();

            // Customers
            CreateMap<ImportCustomerDto, Customer>();

            // Sales
            CreateMap<ImportSaleDto, Sale>();
        }
    }
}
