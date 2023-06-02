﻿namespace Boardgames.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Boardgame")]
    public class ExportCreatorBoardgamesDto
    {
        [XmlElement("BoardgameName")]
        public string BoardgameName { get; set; } = null!;

        [XmlElement("BoardgameYearPublished")]
        public int BoardgameYearPublished { get; set; }
    }
}
