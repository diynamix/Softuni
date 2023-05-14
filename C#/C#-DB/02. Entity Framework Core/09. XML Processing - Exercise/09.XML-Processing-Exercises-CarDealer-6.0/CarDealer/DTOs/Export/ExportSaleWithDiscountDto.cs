﻿namespace CarDealer.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("sale")]
    public class ExportSaleWithDiscountDto
    {
        [XmlElement("car")]
        public ExportCarDtoAttributes Car { get; set; } = null!;

        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; } = null!;

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("price-with-discount")]
        public decimal PriceWithDiscount { get; set; }
    }
}
