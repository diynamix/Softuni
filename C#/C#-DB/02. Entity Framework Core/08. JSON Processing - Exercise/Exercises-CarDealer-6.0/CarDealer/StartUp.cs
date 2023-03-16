namespace CarDealer
{
    using System.Globalization;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    using Data;
    using DTOs.Export;
    using DTOs.Import;
    using Models;

    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //string inputJson = File.ReadAllText(@"../../../Datasets/sales.json");
            //string result = ImportSales(context, inputJson);
            //Console.WriteLine(result);

            string outputJson = GetSalesWithAppliedDiscount(context);
            File.WriteAllText(@"../../../Results/sales-discounts.json", outputJson);
        }

        // 1. Setup Database --------------------------------------------------------

        // 2. Import Data -----------------------------------------------------------

        // Query 9. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportSupplierDto[] supplierDtos = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);

            Supplier[] suppliers = mapper.Map<Supplier[]>(supplierDtos);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            
            return $"Successfully imported {suppliers.Length}.";
        }

        // Query 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            // DTO
            IMapper mapper = CreateMapper();

            ImportPartDto[] partDtos = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson);

            ICollection<Part> parts = new HashSet<Part>();

            foreach (ImportPartDto partDto in partDtos)
            {
                if (!context.Suppliers.Any(s => s.Id == partDto.SupplierId))
                {
                    continue;
                }

                Part part = mapper.Map<Part>(partDto);

                parts.Add(part);
            }

            //var parts = JsonConvert
            //    .DeserializeObject<List<Part>>(inputJson)
            //    .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
            //    .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        // Query 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            ImportCarDto[] carDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            ICollection<Car> cars = new HashSet<Car>();
            ICollection<PartCar> partsCars = new HashSet<PartCar>();

            foreach (ImportCarDto carDto in carDtos)
            {
                Car car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance
                };
                cars.Add(car);

                foreach (int part in carDto.PartsId.Distinct())
                {
                    PartCar partCar = new PartCar()
                    {
                        Car = car,
                        PartId = part,
                    };
                    partsCars.Add(partCar);
                }
            }

            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(partsCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        // Query 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCustomerDto[] customerDtos = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);

            Customer[] customers = mapper.Map<Customer[]>(customerDtos);

            //Customer[] customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        // Query 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportSaleDto[] saleDtos = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson);

            Sale[] sales = mapper.Map<Sale[]>(saleDtos);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }


        // 3. Export Data -----------------------------------------------------------

        // Query 14. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture),
                    c.IsYoungDriver
                })
                .ToArray();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        // Query 15. Export Cars from Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();

            ExportCarsFromMakeToyotaDto[] carDtos = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .AsNoTracking()
                .ProjectTo<ExportCarsFromMakeToyotaDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(carDtos, Formatting.Indented);
        }

        // Query 16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count,
                })
                .ToArray();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        // Query 17. Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TraveledDistance
                    },
                    parts = c.PartsCars
                        .Select(pc => new
                        {
                            pc.Part.Name,
                            Price = pc.Part.Price.ToString("f2"),
                        })
                        .ToArray(),
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);
        }

        // Query 18. Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.SelectMany(s => s.Car.PartsCars.Select(pc => pc.Part.Price)).Sum(),
                })
                .AsNoTracking()
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToArray();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        // Query 19. Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TraveledDistance,
                    },
                    customerName = s.Customer.Name,
                    discount = s.Discount.ToString("f2"),
                    price = s.Car.PartsCars.Sum(pc => pc.Part.Price).ToString("f2"),
                    priceWithDiscount = (s.Car.PartsCars.Sum(pc => pc.Part.Price) * (1 - s.Discount / 100)).ToString("f2")
                })
                .ToArray();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }


        // --------------------------------------------------------------------------
        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
        }
    }
}