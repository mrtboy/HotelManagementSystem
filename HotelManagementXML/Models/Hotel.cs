using System;
using System.Xml.Serialization;

namespace HotelManagementXML.Models
{
    [XmlRoot("Hotel")]
    public class Hotel
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("constructionDate")]
        public DateTime ConstructionDate { get; set; }
        [XmlElement("address")]
        public string Address { get; set; }
        [XmlElement("star")]
        public int Star { get; set; }

        public Hotel()
        {
        }

        public Hotel(string name, DateTime constructionDate, string address, int star)
        {
            Name = name;
            ConstructionDate = constructionDate;
            Address = address;
            Star = star;
        }

        //TODO: Dynamic List of rooms and customers

        public override string ToString()
        {
            return Name + "," + ConstructionDate + "," + Address + "," +Star;
        }
    }
}
