namespace Boardgames.DataProcessor
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    
    using Data;
    using ExportDto;
    using Utilities;

    public class Serializer
    {
        private static XmlHelper xmlHelper;

        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            xmlHelper = new XmlHelper();

            ExportCreatorWithTheirBoardgamesDto[] creatorDtos = context.Creators
                .Where(c => c.Boardgames.Any())
                //.Select(c => new ExportCreatorWithTheirBoardgamesDto
                //{
                //    CreatorFullName = $"{c.FirstName} {c.LastName}",
                //    BoardgamesCount = c.Boardgames.Count,
                //    Boardgames = c.Boardgames
                //        .Select(bg => new ExportCreatorBoardgamesDto
                //        {
                //            BoardgameName = bg.Name,
                //            BoardgameYearPublished = bg.YearPublished,
                //        })
                //        .OrderBy(bg => bg.BoardgameName)
                //        .ToArray()
                //})
                .ProjectTo<ExportCreatorWithTheirBoardgamesDto>(mapper.ConfigurationProvider)
                .ToArray()
                .OrderByDescending(c => c.BoardgamesCount)
                .ThenBy(c => c.CreatorFullName)
                .ToArray();

            return xmlHelper.Serialize(creatorDtos, "Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            // TO DO...As DTO
            //ExportSellerWithMostBoardgamesDto[] sellers = context.Sellers...
            
            var sellers = context.Sellers
                .Include(s => s.BoardgamesSellers)
                .ThenInclude(bs => bs.Boardgame)
                .AsNoTracking()
                .ToArray()
                .Where(s => s.BoardgamesSellers.Any(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
                .Select(s => new
                {
                    Name = s.Name,
                    Website = s.Website,
                    Boardgames = s.BoardgamesSellers
                        .Where(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating)
                        .Select(bs => new
                        {
                            Name = bs.Boardgame.Name,
                            Rating = bs.Boardgame.Rating,
                            Mechanics = bs.Boardgame.Mechanics,
                            Category = bs.Boardgame.CategoryType.ToString(),
                        })
                        .OrderByDescending(b => b.Rating)
                        .ThenBy(b => b.Name)
                        .ToArray()
                })
                .OrderByDescending(s => s.Boardgames.Length)
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);
        }

        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BoardgamesProfile>();
            }));
    }
}