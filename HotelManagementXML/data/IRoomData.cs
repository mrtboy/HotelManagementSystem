using System.Collections.Generic;
using HotelManagementXML.Models;

namespace HotelManagementXML.data
{
    interface IRoomData
    {
        string AddNewRoom(Room room);
        List<string> GetAllRooms();
        List<string> GetAvailableRooms();
        string FindRoomInformation(int roomNumber);
    }
}
