namespace CarDealer.DTOs.Import
{
    using System.Xml.Serialization;

    [XmlType("Customer")]
    public class ImportCustomerDto
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        // Always read datetime, emums and other hard to parse data types as string
        // Parse it yourself in your business logic
        // JsonConvers and XmlSerializer are not capable of parsing!
        [XmlElement("birthDate")]
        public string BirthDate { get; set; }

        [XmlElement("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}
