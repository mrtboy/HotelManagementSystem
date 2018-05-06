using System.Collections.Generic;
using HotelManagementJSON.Models;

namespace HotelManagementJSON.data
{
    public class HotelData : IHotelData
    {
        IRepository repo;

        public HotelData()
        {
            this.repo = new JSONReadWrite();
        }

        public string AddHotel(Hotel hotel)
        {
            return repo.WriteToFile("Hotel", hotel);
        }

        public List<string> GetAllHotels()
        {
            return repo.GetAll("Hotel");
        }
    }
}
