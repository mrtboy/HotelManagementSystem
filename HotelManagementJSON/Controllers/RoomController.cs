using HotelManagementJSON.data;
using HotelManagementJSON.Models;
using System;
using System.Collections.Generic;

namespace HotelManagementJSON.Controllers
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

        public string GetRoomInfo(int roomNumber)
        {
            return data.FindRoomInformation(roomNumber);
        }

        public List<string> ShowAllRooms()
        {
            return data.GetAllRooms();
        }

        public List<string> ShowAvailableRooms()
        {
            return data.GetAvailableRooms();
        }

    }
}
