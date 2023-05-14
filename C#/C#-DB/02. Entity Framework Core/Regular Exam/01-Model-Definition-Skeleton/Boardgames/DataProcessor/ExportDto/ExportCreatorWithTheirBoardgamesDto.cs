namespace Boardgames.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Creator")]
    public class ExportCreatorWithTheirBoardgamesDto
    {
        [XmlElement("CreatorName")]
        public string CreatorFullName { get; set; } = null!;

        [XmlAttribute("BoardgamesCount")]
        public int BoardgamesCount { get; set; }

        [XmlArray("Boardgames")]
        public ExportCreatorBoardgamesDto[] Boardgames { get; set; } = null!;
    }
}
