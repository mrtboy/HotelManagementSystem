﻿using HotelManagement2.Models;
using System.Collections.Generic;

namespace HotelManagement2.data
{
    interface IHotelData
    {
        string AddHotel(Hotel hotel);
        List<string> GetAllHotels();
    }
}
