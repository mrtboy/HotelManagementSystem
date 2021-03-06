﻿using HotelManagement2.data;
using HotelManagement2.Models;
using System;
using System.Collections.Generic;

namespace HotelManagement2.Controllers
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
