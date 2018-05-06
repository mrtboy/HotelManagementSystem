using System;

namespace HotelManagement.Models
{
    [Serializable]
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int RoomNumber { get; set; }
        public DateTime ArrivalDate { get; set; }
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
