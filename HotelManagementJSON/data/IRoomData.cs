using System.Collections.Generic;
using HotelManagementJSON.Models;

namespace HotelManagementJSON.data
{
    interface IRoomData
    {
        string AddNewRoom(Room room);
        List<string> GetAllRooms();
        List<string> GetAvailableRooms();
        string FindRoomInformation(int roomNumber);
    }
}
