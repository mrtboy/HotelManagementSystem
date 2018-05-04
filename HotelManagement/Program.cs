using HotelManagement.Controllers;
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Views;

namespace HotelManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            HotelManagementView customerView = new HotelManagementView();
            customerView.MainMenu();
        }

    }
}
