﻿using System.Collections.Generic;
using HotelManagement2.Models;

namespace HotelManagement2.data
{
    interface IRoomData
    {
        string AddNewRoom(Room room);
        List<string> GetAllRooms();
        List<string> GetAvailableRooms();
        string FindRoomInformation(int roomNumber);
    }
}
