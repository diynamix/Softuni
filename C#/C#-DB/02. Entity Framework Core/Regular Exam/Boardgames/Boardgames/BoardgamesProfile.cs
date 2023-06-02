namespace Boardgames
{
    using AutoMapper;

    using Data.Models;
    using DataProcessor.ExportDto;
    using DataProcessor.ImportDto;

    public class BoardgamesProfile : Profile
    {
        // DO NOT CHANGE OR RENAME THIS CLASS!
        public BoardgamesProfile()
        {
            // Boardgame
            CreateMap<ImportBoardgameDto, Boardgame>();

            CreateMap<Boardgame, ExportCreatorBoardgamesDto>()
                .ForMember(d => d.BoardgameName, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.BoardgameYearPublished, opt => opt.MapFrom(s => s.YearPublished));            

            // Creator
            CreateMap<ImportCreatorDto, Creator>();

            CreateMap<Creator, ExportCreatorWithTheirBoardgamesDto>()
                .ForMember(d => d.CreatorFullName, opt => opt.MapFrom(s => $"{s.FirstName} {s.LastName}"))
                .ForMember(d => d.BoardgamesCount, opt => opt.MapFrom(s => s.Boardgames.Count))
                .ForMember(d => d.Boardgames,
                    opt => opt.MapFrom(s => s.Boardgames
                        //.Select(b => b)
                        //.Select(b => new ExportCreatorBoardgamesDto())
                        .OrderBy(bg => bg.Name)
                        .ToArray()));

            // Seller
            CreateMap<ImportSellerDto, Seller>();

            // TO DO...(in Serializer ExportSellersWithMostBoardgames() with DTO)
            CreateMap<Seller, ExportSellerWithMostBoardgamesDto>();
        }
    }
}