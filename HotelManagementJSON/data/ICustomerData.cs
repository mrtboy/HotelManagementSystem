using HotelManagementJSON.Models;
using System.Collections.Generic;

namespace HotelManagementJSON.data
{
    interface ICustomerData
    {
        bool WriteNewCustomer(Customer customer);
        string FindCustomerByName(string name);
        List<string> GetAllCustomers();
    }
}
