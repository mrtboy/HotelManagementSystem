namespace HotelManagement.Models
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public  string AreaType { get; set; }
        public decimal Price { get; set; }
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
        
