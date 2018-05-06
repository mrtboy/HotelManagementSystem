using HotelManagementJSON.Models;
using System.Collections.Generic;

namespace HotelManagementJSON.Controllers
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
