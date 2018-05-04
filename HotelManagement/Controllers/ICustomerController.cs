using HotelManagement.Models;
using System.Collections.Generic;

namespace HotelManagement.Controllers
{
    interface ICustomerController
    {
        bool AddNewCustomer(Customer customer);
        List<string> GetAllCustomers();
        bool RemoveCustomer(int id);
        bool FindCustomer(int id);
        string SearchCustomerByName(string name);
    }
}
