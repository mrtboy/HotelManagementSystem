using HotelManagementJSON.Models;
using System.Collections.Generic;

namespace HotelManagementJSON.data
{
    interface IHotelData
    {
        string AddHotel(Hotel hotel);
        List<string> GetAllHotels();
    }
}
