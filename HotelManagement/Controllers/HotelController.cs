using System.Collections.Generic;
using HotelManagement.data;
using HotelManagement.Models;

namespace HotelManagement.Controllers
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
