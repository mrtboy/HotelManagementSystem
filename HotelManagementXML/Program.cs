using HotelManagementXML.Controllers;
using HotelManagementXML.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementXML.Views;

namespace HotelManagementXML
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
