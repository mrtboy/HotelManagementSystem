using HotelManagement.Models;
using System.Collections.Generic;

namespace HotelManagement.data
{
    interface ICustomerData
    {
        bool WriteNewCustomer(Customer customer);
        string FindCustomerByName(string name);
        List<string> GetAllCustomers();
    }
}
