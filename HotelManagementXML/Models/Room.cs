using System;
using System.Xml.Serialization;

namespace HotelManagementXML.Models
{
    [XmlRoot("Room")]
    public class Room
    {
        [XmlElement("roomNumber")]
        public int RoomNumber { get; set; }
        [XmlElement("areaType")]
        public  string AreaType { get; set; }
        [XmlElement("price")]
        public decimal Price { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }


        public Room() { }

        public Room(int roomNumber, string areaType, decimal price, string description)
        {
            RoomNumber = roomNumber;
            AreaType = areaType;
            Price = price;
            Description = description;
        }

        public override string ToString()
        {
            return RoomNumber + "," + AreaType + "," + Price + "," + Description;
        }
    }
}
        
