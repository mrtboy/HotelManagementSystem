using System.Collections.Generic;
using HotelManagementXML.data;
using HotelManagementXML.Models;

namespace HotelManagementXML.Controllers
{
    public class HotelController : IHotelController
    {
        IHotelData data;

        public HotelController()
        {
            this.data = new HotelData();
        }

        public string AddNewHotel(Hotel hotel)
        {
            return data.AddHotel(hotel);
        }

        public List<string> ShowAllHotels()
        {
            return data.GetAllHotels();
        }
    }
}
