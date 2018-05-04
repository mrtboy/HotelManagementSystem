﻿using HotelManagement.Models;

namespace HotelManagement.data
{
    public class HotelData : IHotelData
    {
        IRepository repo;

        public HotelData()
        {
            this.repo = new FileReadWrite();
        }

        public string AddHotel(Hotel hotel)
        {
            return repo.WriteToFile("Hotel", hotel);
        }
    }
}