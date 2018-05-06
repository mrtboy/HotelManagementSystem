using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace HotelManagementJSON.Models
{
    [DataContract]
    public class Room
    {
        [DataMember]
        public int RoomNumber { get; set; }
        [DataMember]
        public  string AreaType { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
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
        
