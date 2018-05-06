using HotelManagement.Models;
using System;
using System.Collections.Generic;

namespace HotelManagement.data
{
    public class CustomerData : ICustomerData
    {
        IRepository repo;

        public CustomerData()
        {
            this.repo = new BinaryReadWrite();
        }

        public string FindCustomerByName(string name)
        {
            return repo.Search(name,"Customer");
        }

        public bool WriteNewCustomer(Customer customer)
        {
            try
            {
                repo.WriteToFile("Customer", customer);
                return true;
            }catch(Exception)
            {
                return false;
            }
        }

        public List<string> GetAllCustomers()
        {
            return repo.GetAll("Customer");
        }
    }
}
