using HotelManagement.Controllers;
using HotelManagement.Models;
using System;

namespace HotelManagement.Views
{
    public class HotelManagementView
    {
        ICustomerController customerController;
        IHotelController hotelController;
        public HotelManagementView()
        {
            customerController = new CustomerController();
            hotelController = new HotelController();
        }

        public void MainMenu()
        {
            Console.WriteLine("==>Welcome to Hotel Management system<==");
            Console.WriteLine("1. Hotel Management");
            Console.WriteLine("2. Customer Management");
            Console.WriteLine("0. Quite");

            try
            {
                int input = -1;
                input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        HotelManagementMenu();
                        break;
                    case 2:
                        CustomerMunu();
                        break;
                    case 0:
                        return;
                    default:
                        break;
                }
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void HotelManagementMenu()
        {
            Console.WriteLine("==>Hotel Management<==");
            Console.WriteLine("1. Add Hotel");
            Console.WriteLine("2. Add Room");
            Console.WriteLine("3. Show All Rooms");
            Console.WriteLine("4. Show Available Rooms");
            Console.WriteLine("9. Menu Menu");
            Console.WriteLine("0. Quiet");
            try
            {
                int input = -1;
                input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        AddHotelMenu();
                        break;
                    case 2:
                        AddRoomMenu();
                        break;
                    case 3:
                        ShowAllRoomsMenu();
                        break;
                    case 4:
                        ShowAvailableRoomsMenu();
                        break;
                    case 9:
                        MainMenu();
                        break;
                    case 0:
                        return;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private void ShowAvailableRoomsMenu()
        {
            throw new NotImplementedException();
        }

        private void ShowAllRoomsMenu()
        {
            throw new NotImplementedException();
        }

        private void AddRoomMenu()
        {
            throw new NotImplementedException();
        }

        private void AddHotelMenu()
        {
            Console.WriteLine("==>Add new Hotel<==");
            Console.Write("Hotel Name: ");
            string name = Console.ReadLine();
            Console.Write("Construction Date: ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("How many Stars? ");
            int star = int.Parse(Console.ReadLine());
            Hotel hotel = new Hotel(name,date,address,star);
            Console.WriteLine(hotelController.AddNewHotel(hotel));
            HotelManagementMenu();
        }

        private void CustomerMunu()
        {
            Console.WriteLine("==>Cusomer Console<==");
            Console.WriteLine("1. Add new Customer.");
            Console.WriteLine("2. Search Customer by name.");
            Console.WriteLine("3. Show all Customers.");
            Console.WriteLine("9. Menu Menu");
            Console.WriteLine("0. Quiet");

            Console.WriteLine("Please enter the Menu number: ");

            try
            {
                int element = 100;
                element = int.Parse(Console.ReadLine());

                switch (element)
                {
                    case 1:
                        addNewCusomerMenu();
                        break;
                    case 2:
                        searchCustomerByNameMenu();
                        break;
                    case 3:
                        showAllCustomersMenu();
                        break;
                    case 9:
                        MainMenu();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Menu not exist.");
                        break;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void addNewCusomerMenu()
        {
            try
            {
                Console.WriteLine("==>Add New Customer Menu<== ");
                Console.Write("Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Address: ");
                string address = Console.ReadLine();
                Console.Write("Room Number: ");
                int roomNumber = int.Parse(Console.ReadLine());
                Console.Write("Arrival Date: (dd/mm/yyyy)");
                DateTime arrivalDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Length of stay: ");
                int lengthOfStay = int.Parse(Console.ReadLine());

                customerController.AddNewCustomer(new Customer(id, name, address, roomNumber, arrivalDate, lengthOfStay));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void searchCustomerByNameMenu()
        {
            try
            {
                Console.WriteLine("==>Search Customer<==");
                Console.Write("Please Enter the Customer Name: ");
                string name = Console.ReadLine();
                Console.WriteLine(customerController.SearchCustomerByName(name));

                CustomerMunu();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void showAllCustomersMenu()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("==>Show all Customers<==");
            foreach(string customer in customerController.GetAllCustomers())
            {
                Console.WriteLine(customer);
            }
            Console.WriteLine("=====================================");
            CustomerMunu();
        }
    }
}
