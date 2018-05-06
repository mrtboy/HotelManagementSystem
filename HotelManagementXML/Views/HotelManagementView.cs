using HotelManagementXML.Controllers;
using HotelManagementXML.Models;
using System;

namespace HotelManagementXML.Views
{
    public class HotelManagementXMLView
    {
        ICustomerController customerController;
        IHotelController hotelController;
        IRoomController roomController;
        public HotelManagementXMLView()
        {
            customerController = new CustomerController();
            hotelController = new HotelController();
            roomController = new RoomController();
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
                        HotelManagementXMLMenu();
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

        private void HotelManagementXMLMenu()
        {
            Console.WriteLine("==>Hotel Management<==");
            Console.WriteLine("1. Add Hotel");
            Console.WriteLine("2. Add Room");
            Console.WriteLine("3. Show All Rooms");
            Console.WriteLine("4. Show Available Rooms");
            Console.WriteLine("5. Show All Hotells");
            Console.WriteLine("6. Get Room Info");
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
                    case 5:
                        ShowAllHotelsMenu();
                        break;
                    case 6:
                        GetRoomInfoMenu();
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

        private void GetRoomInfoMenu()
        {
            Console.WriteLine("=====================");
            Console.WriteLine("==>Room Information<==");
            Console.Write("Please Enter Room Number: ");
            int roomNumber = int.Parse(Console.ReadLine());
            Console.WriteLine(roomController.GetRoomInfo(roomNumber));
            Console.WriteLine("=====================");
            HotelManagementXMLMenu();
        }

        private void ShowAllHotelsMenu()
        {
            Console.WriteLine("====================");
            foreach (string hotel in hotelController.ShowAllHotels())
            {
                Console.WriteLine(hotel);
            }
            Console.WriteLine("====================");
            HotelManagementXMLMenu();
        }

        private void ShowAvailableRoomsMenu()
        {
            Console.WriteLine("==>Show Available Room<==");
            foreach(string room in roomController.ShowAvailableRooms())
            {
                Console.WriteLine(room);
            }
            Console.WriteLine("=========================");
            HotelManagementXMLMenu();
        }

        private void ShowAllRoomsMenu()
        {
            Console.WriteLine("========================");
            foreach (string room in roomController.ShowAllRooms())
            {
                Console.WriteLine(room);
            }
            Console.WriteLine("========================");
            HotelManagementXMLMenu();
        }

        private void AddRoomMenu()
        {
            Console.WriteLine("========================");
            Console.WriteLine("==>Add new Room<==");
            Console.Write("Room Number: ");
            int roomNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter Area Type: ");
            string areaType = Console.ReadLine();
            Console.Write("Price per night: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Room room = new Room(roomNumber, areaType, price, description); 
            roomController.AddNewRoom(room);
            HotelManagementXMLMenu();
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
            HotelManagementXMLMenu();
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
                CustomerMunu();
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
