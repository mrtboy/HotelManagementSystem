using HotelManagement.Models;
using System.Collections.Generic;

namespace HotelManagement.Controllers
{
    public interface IHotelController
    {
        string AddNewHotel(Hotel hotel);
        List<string> ShowAllHotels();
    }
}
