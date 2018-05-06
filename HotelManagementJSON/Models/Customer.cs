using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace HotelManagementJSON.Models
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public int RoomNumber { get; set; }
        [DataMember]
        public DateTime ArrivalDate { get; set; }
        [DataMember]
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
