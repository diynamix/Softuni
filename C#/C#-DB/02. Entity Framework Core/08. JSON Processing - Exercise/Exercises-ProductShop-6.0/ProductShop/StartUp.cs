namespace ProductShop
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    using Data;
    using DTOs.Import;
    using DTOs.Export;
    using Models;

    /// <summary>
    /// On import use DTO
    /// On export use anonymous object
    /// </summary>
    public class StartUp
    {
        //private static IMapper mapper;

        public static void Main()
        {
            //mapper = new Mapper(new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<ProductShopProfile>();
            //}));

            ProductShopContext context = new ProductShopContext();


            ////string inputJson = File.ReadAllText(@"../../../Datasets/categories-products.json");
            //string result = ImportCategoryProducts(context, inputJson);

            string result = GetUsersWithProducts(context);
            Console.WriteLine(result);
        }

        // 1. Import Data ------------------------------------------------------------------

        // Query 1. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportUserDto[] userDtos =
                JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            // Automapper can map collections also
            // In case of no validation
            //User[] users = mapper.Map<User[]>(userDtos);

            // This way allows you additional validation
            ICollection<User> users = new HashSet<User>();

            foreach (var userDto in userDtos)
            {
                User user = mapper.Map<User>(userDto);

                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        // Query 2. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportProductDto[] productDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);

            Product[] products = mapper.Map<Product[]>(productDtos);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        // Query 3. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            // In this collection of Dtos, there can be invalid entries
            ImportCategoryDto[] categoryDtos = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);

            ICollection<Category> validCatecories = new HashSet<Category>();

            foreach (ImportCategoryDto categoryDto in categoryDtos)
            {
                if (String.IsNullOrEmpty(categoryDto.Name))
                {
                    continue;
                }

                Category category = mapper.Map<Category>(categoryDto);
                validCatecories.Add(category);
            }

            context.Categories.AddRange(validCatecories);
            context.SaveChanges();

            return $"Successfully imported {validCatecories.Count}";
        }

        // Query 4. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCategoryProductDto[] categoryProductDtos = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            ICollection<CategoryProduct> validEntries = new HashSet<CategoryProduct>();

            foreach (ImportCategoryProductDto cpDto in categoryProductDtos)
            {
                //if (!context.Categories.Any(c => c.Id == cpDto.CategoryId)
                //    || !context.Products.Any(p => p.Id == cpDto.ProductId))
                //{
                //    continue;
                //}

                CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(cpDto);

                validEntries.Add(categoryProduct);
            }

            context.CategoriesProducts.AddRange(validEntries);
            context.SaveChanges();

            return $"Successfully imported {validEntries.Count}";
        }


        // 2. Export Data ------------------------------------------------------------------

        // Query 5. Export Products in Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            // Anonymous object + Manual mapping
            // DTO + Manual maping
            // DTO + Automapper

            // Anonymous object + Manual mapping
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName,
                })
                .AsNoTracking()
                .ToArray();

            //return JsonConvert.SerializeObject(products, Formatting.Indented);


            // DTO + Automapper
            IMapper mapper = CreateMapper();

            ExportProductsInRangeDto[] productsDtos = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .AsNoTracking()
                .ProjectTo<ExportProductsInRangeDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(productsDtos, Formatting.Indented);
        }

        // Query 6. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            IContractResolver contractResolver = ConfigureCamelCaseNaming();

            var usersWithSoldProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName,
                        })
                        .ToArray(),
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(usersWithSoldProducts,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver,
                });
        }

        // Query 7. Export Categories by Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            IContractResolver contractResolver = ConfigureCamelCaseNaming();

            var categories = context.Categories
                .OrderByDescending(c => c.CategoriesProducts.Count)
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoriesProducts.Count,
                    AveragePrice = (c.CategoriesProducts.Any() ? c.CategoriesProducts.Average(cp => cp.Product.Price) : 0).ToString("f2"),
                    TotalRevenue = (c.CategoriesProducts.Any() ? c.CategoriesProducts.Sum(cp => cp.Product.Price) : 0).ToString("f2"),
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(categories,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver,
                });
        }

        // Query 8. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            IContractResolver contractResolver = ConfigureCamelCaseNaming();

            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                { // UserDTO
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    { // ProductWrapperDTO
                        Count = u.ProductsSold.Count(p => p.Buyer != null),
                        Products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new
                            { // ProductDTO
                                p.Name,
                                p.Price,
                            })
                            .ToArray(),
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .AsNoTracking()
                .ToArray();

            // UserWrapperDTO
            var userWrapperDto = new
            {
                UsersCount = users.Length,
                Users = users,
            };

            return JsonConvert.SerializeObject(userWrapperDto,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver,
                    NullValueHandling = NullValueHandling.Ignore,
                });
        }


        // Static Methods ------------------------------------------------------------------
        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
        }

        private static IContractResolver ConfigureCamelCaseNaming()
        {
            return new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true),
            };
        }
    }
}