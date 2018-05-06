using System.Collections.Generic;
using HotelManagement.Models;

namespace HotelManagement.data
{
    public class HotelData : IHotelData
    {
        IRepository repo;

        public HotelData()
        {
            this.repo = new SerializationReadWrite();
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
