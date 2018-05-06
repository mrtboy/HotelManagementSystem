using HotelManagementXML.Models;
using System.Collections.Generic;

namespace HotelManagementXML.Controllers
{
    public interface IHotelController
    {
        string AddNewHotel(Hotel hotel);
        List<string> ShowAllHotels();
    }
}
