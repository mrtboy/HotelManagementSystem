using HotelManagement.data;
using HotelManagement.Models;
using System;
using System.Collections.Generic;

namespace HotelManagement.Controllers
{
    public class CustomerController : ICustomerController
    {
        ICustomerData data;

        public CustomerController()
        {
            data = new CustomerData();
        }

        public bool AddNewCustomer(Customer customer)
        {
            return data.WriteNewCustomer(customer);
        }

        

        public bool FindCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllCustomers()
        {
            return data.GetAllCustomers();
        }

        public bool RemoveCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public string SearchCustomerByName(string name)
        {
            return data.FindCustomerByName(name);
        }
    }
}
