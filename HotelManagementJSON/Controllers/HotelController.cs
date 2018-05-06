using System.Collections.Generic;
using HotelManagementJSON.data;
using HotelManagementJSON.Models;

namespace HotelManagementJSON.Controllers
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
