using System.Collections.Generic;
using HotelManagement.Models;

namespace HotelManagement.data
{
    interface IRoomData
    {
        string AddNewRoom(Room room);
        List<string> GetAllRooms();
        List<string> GetAvailableRooms();
        string FindRoomInformation(int roomNumber);
    }
}
