using HotelManagementXML.Models;
using System.Collections.Generic;

namespace HotelManagementXML.data
{
    interface IHotelData
    {
        string AddHotel(Hotel hotel);
        List<string> GetAllHotels();
    }
}
