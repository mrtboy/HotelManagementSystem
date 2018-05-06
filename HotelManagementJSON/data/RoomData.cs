using System.Collections.Generic;
using HotelManagementJSON.Models;

namespace HotelManagementJSON.data
{
    public class RoomData : IRoomData
    {
        IRepository repo;

        public RoomData()
        {
            this.repo = new JSONReadWrite();
        }

        public string AddNewRoom(Room room)
        {
            return repo.WriteToFile("Room",room);
        }

        public string FindRoomInformation(int roomNumber)
        {
            return repo.GetRoomInfo(roomNumber);
        }

        public List<string> GetAllRooms()
        {
            return repo.GetAll("Room");
        }

        public List<string> GetAvailableRooms()
        {
            return repo.GetAvailableRooms("Room", "Customer");
        }
    }
}
