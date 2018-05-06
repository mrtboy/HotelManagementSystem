using HotelManagementXML.Models;
using System.Collections.Generic;

namespace HotelManagementXML.Controllers
{
    interface IRoomController
    {
        string AddNewRoom(Room room);
        List<string> ShowAllRooms();
        List<string> ShowAvailableRooms();
        string GetRoomInfo(int roomNumber);
    }
}
