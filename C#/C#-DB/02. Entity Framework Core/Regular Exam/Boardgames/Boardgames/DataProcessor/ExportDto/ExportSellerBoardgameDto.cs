namespace Boardgames.DataProcessor.ExportDto
{
    public class ExportSellerBoardgameDto
    {
        public string Name { get; set; } = null!;

        public double Rating { get; set; }

        public string Mechanics { get; set; }

        public string Category { get; set; }
    }
}
