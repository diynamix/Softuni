namespace Boardgames.DataProcessor.ExportDto
{
    public class ExportSellerWithMostBoardgamesDto
    {
        public string Name { get; set; } = null!;

        public string Website { get; set; } = null!;

        public ExportSellerBoardgameDto[] Boardgames { get; set;} = null!;
    }
}
