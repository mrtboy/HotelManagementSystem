﻿using HotelManagement2.Controllers;
using HotelManagement2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement2.Views;

namespace HotelManagement2
{
    class Program
    {
        static void Main(string[] args)
        {
            HotelManagement2View customerView = new HotelManagement2View();
            customerView.MainMenu();
        }

    }
}
