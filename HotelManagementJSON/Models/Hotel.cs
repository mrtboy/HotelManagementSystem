using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace HotelManagementJSON.Models
{
    [DataContract]
    public class Hotel
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime ConstructionDate { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
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
