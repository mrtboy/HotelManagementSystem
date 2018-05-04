namespace HotelManagement.Models
{
    public enum Area
    {
        Single,
        Double,
        Family
    }
    public class Room
    {
        public int RoomNumber { get; set; }
        public  Area AreaType { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }


        public Room() { }

        public Room(int roomNumber, Area areaType, decimal price, string description)
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
        
