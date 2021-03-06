﻿using HotelManagement2.Models;
using System.Collections.Generic;

namespace HotelManagement2.data
{
    interface ICustomerData
    {
        bool WriteNewCustomer(Customer customer);
        string FindCustomerByName(string name);
        List<string> GetAllCustomers();
    }
}
