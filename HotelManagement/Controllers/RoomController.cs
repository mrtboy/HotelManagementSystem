using HotelManagement.data;
using HotelManagement.Models;
using System;

namespace HotelManagement.Controllers
{
    public class RoomController : IRoomController
    {
        IRoomData data;

        public RoomController()
        {
            data = new RoomData();
        }

        public string AddNewRoom(Room room)
        {
            return data.AddNewRoom(room);
        }
    }
}
