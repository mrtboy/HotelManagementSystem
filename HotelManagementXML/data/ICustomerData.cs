using HotelManagementXML.Models;
using System.Collections.Generic;

namespace HotelManagementXML.data
{
    interface ICustomerData
    {
        bool WriteNewCustomer(Customer customer);
        string FindCustomerByName(string name);
        List<string> GetAllCustomers();
    }
}
