using HotelManagementJSON.Controllers;
using HotelManagementJSON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementJSON.Views;

namespace HotelManagementJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            HotelManagementXMLView customerView = new HotelManagementXMLView();
            customerView.MainMenu();
        }

    }
}
