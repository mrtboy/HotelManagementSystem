using HotelManagementJSON.Models;
using System.Collections.Generic;

namespace HotelManagementJSON.Controllers
{
    interface IRoomController
    {
        string AddNewRoom(Room room);
        List<string> ShowAllRooms();
        List<string> ShowAvailableRooms();
        string GetRoomInfo(int roomNumber);
    }
}
