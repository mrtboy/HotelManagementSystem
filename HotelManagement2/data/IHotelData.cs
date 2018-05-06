using HotelManagement.Models;
using System.Collections.Generic;

namespace HotelManagement.data
{
    interface IHotelData
    {
        string AddHotel(Hotel hotel);
        List<string> GetAllHotels();
    }
}
