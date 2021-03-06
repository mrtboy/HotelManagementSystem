﻿using System.Collections.Generic;
using HotelManagement2.data;
using HotelManagement2.Models;

namespace HotelManagement2.Controllers
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
