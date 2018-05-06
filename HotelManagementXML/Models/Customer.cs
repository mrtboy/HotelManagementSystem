using System;
using System.Xml;
using System.Xml.Serialization;

namespace HotelManagementXML.Models
{
    [XmlRoot("Customer")]
    public class Customer
    {
        [XmlElement("id")]
        public int Id { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("address")]
        public string Address { get; set; }
        [XmlElement("roomNumber")]
        public int RoomNumber { get; set; }
        [XmlElement("arrivalDate")]
        public DateTime ArrivalDate { get; set; }
        [XmlElement("lengthOfStay")]
        public int LengthOfStay { get; set; }

        public Customer() { }

        public Customer(int id, string name, string address, int roomNumber, DateTime arrivalDate, int lengthOfStay)
        {
            Id = id;
            Name = name;
            Address = address;
            RoomNumber = roomNumber;
            ArrivalDate = arrivalDate;
            LengthOfStay = lengthOfStay;
        }

        public override string ToString()
        {
            string text = Id + "," + Name + "," + Address + "," + RoomNumber + "," + ArrivalDate + "," + LengthOfStay;
            return text;
        }
    }
}
