﻿using HotelManagement2.Models;
using System.Collections.Generic;

namespace HotelManagement2.Controllers
{
    interface IRoomController
    {
        string AddNewRoom(Room room);
        List<string> ShowAllRooms();
        List<string> ShowAvailableRooms();
        string GetRoomInfo(int roomNumber);
    }
}
