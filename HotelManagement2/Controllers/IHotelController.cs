﻿using HotelManagement2.Models;
using System.Collections.Generic;

namespace HotelManagement2.Controllers
{
    public interface IHotelController
    {
        string AddNewHotel(Hotel hotel);
        List<string> ShowAllHotels();
    }
}
