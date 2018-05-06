using System.Collections.Generic;
using HotelManagementXML.Models;

namespace HotelManagementXML.data
{
    public class HotelData : IHotelData
    {
        IRepository repo;

        public HotelData()
        {
            this.repo = new XmlReadWrite();
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
