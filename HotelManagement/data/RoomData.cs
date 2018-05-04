using HotelManagement.Models;

namespace HotelManagement.data
{
    public class RoomData : IRoomData
    {
        IRepository repo;

        public RoomData()
        {
            this.repo = new FileReadWrite();
        }

        public string AddNewRoom(Room room)
        {
            return repo.WriteToFile("Room",room);
        }
    }
}
