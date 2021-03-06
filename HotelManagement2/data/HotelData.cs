﻿using System.Collections.Generic;
using HotelManagement2.Models;

namespace HotelManagement2.data
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
