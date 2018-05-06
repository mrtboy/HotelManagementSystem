using HotelManagementJSON.Models;
using System.Collections.Generic;

namespace HotelManagementJSON.Controllers
{
    public interface IHotelController
    {
        string AddNewHotel(Hotel hotel);
        List<string> ShowAllHotels();
    }
}
