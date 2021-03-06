﻿using System.Collections.Generic;
using HotelManagementXML.Models;

namespace HotelManagementXML.data
{
    public class RoomData : IRoomData
    {
        IRepository repo;

        public RoomData()
        {
            this.repo = new XmlReadWrite();
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
