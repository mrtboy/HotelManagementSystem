using System;

namespace HotelManagementXML.Models
{
    [Serializable]
    public class Hotel
    {
        public string Name { get; set; }
        public DateTime ConstructionDate { get; set; }
        public string Address { get; set; }
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
