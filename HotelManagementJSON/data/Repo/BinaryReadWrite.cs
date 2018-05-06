using HotelManagementJSON.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementJSON.data
{
    public class BinaryReadWrite : IRepository
    {
        public List<string> GetAll(string fileName)
        {
            List<string> allLines = new List<string>();
            try
            {
                string path = String.Format(@".\{0}Binary.txt", fileName);
                using (BinaryReader binaryReader = new BinaryReader(new FileStream(path, FileMode.Open)))
                {

                    if (fileName == "Customer")
                    {
                        Customer customer = new Customer();
                        while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                        {
                            customer.Id = binaryReader.ReadInt32();
                            customer.Name = binaryReader.ReadString();
                            customer.RoomNumber = binaryReader.ReadInt32();
                            customer.ArrivalDate = DateTime.Parse(binaryReader.ReadString());
                            customer.LengthOfStay = binaryReader.ReadInt32();

                            allLines.Add(customer.Id + "," + customer.Name + "," + customer.RoomNumber + "," + customer.ArrivalDate + "," + customer.LengthOfStay);
                        }
                    }
                    else if (fileName == "Room")
                    {
                        Room room = new Room();
                        while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                        {
                            room.RoomNumber = binaryReader.ReadInt32();
                            room.AreaType = binaryReader.ReadString();
                            room.Description = binaryReader.ReadString();
                            room.Price = binaryReader.ReadDecimal();

                            allLines.Add(room.RoomNumber + "," + room.AreaType + "," + room.Description + "," + room.Price);
                        }

                    }
                    else if (fileName == "Hotel")
                    {
                        Hotel hotel = new Hotel();
                        while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                        {
                            hotel.Name = binaryReader.ReadString();
                            hotel.Address = binaryReader.ReadString();
                            hotel.ConstructionDate = DateTime.Parse(binaryReader.ReadString());
                            hotel.Star = binaryReader.ReadInt32();

                            allLines.Add(hotel.Name + "," + hotel.Address + "," + hotel.ConstructionDate + "," + hotel.Star);
                        }
                    }
                }

                return allLines;
            }
            catch (IOException e)
            {
                allLines.Add(e.Message);
                return allLines;
            }
        }

        public List<string> GetAvailableRooms(string roomFile, string customerFile)
        {
            List<string> rooms = new List<string>();
            rooms = GetAll("Room");
            List<string> customers = new List<string>();
            customers = GetAll("Customer");
            List<string> availableRooms = new List<string>();
            string roomPath = String.Format(@".\{0}Binary.txt", roomFile);
            string customerPath = String.Format(@".\{0}Binary.txt", customerFile);
            try { 
            
                foreach (string roomInList in rooms)
                {
                    string[] r = roomInList.Split(',');
                    foreach (string customerInList in customers)
                    {
                        string[] c = customerInList.Split(',');
                        if (r[0] == c[2])
                        {
                            availableRooms.Add(roomInList);
                        }
                    }
                }

                return availableRooms;
            }
            catch (IOException e)
            {
                availableRooms.Add(e.Message);
                return availableRooms;
            }
        }

        public string GetRoomInfo(int roomNumber)
        {
            List<string> customers = new List<string>();
            customers = GetAll("Customer");
            List<string> rooms = new List<string>();
            rooms = GetAll("Room");
            List<string> availableRooms = new List<string>();
            string roomPath = String.Format(@".\{0}Binary.txt", "Room");
            string customerPath = String.Format(@".\{0}Binary.txt", "Customer");
            string roomInfo = "";
            string customerInfo = "";
            string result = "";
            try
            {

                //Check room Number in Room file and Room Number in Customer File
                foreach (string room in rooms)
                {
                    string[] r = room.Split(',');
                    if (r[0] == roomNumber.ToString())
                    {
                        roomInfo = room.ToString();
                    }
                }

                //Check if Rooms has Guess
                foreach (string customer in customers)
                {
                    string[] c = customer.Split(',');
                    if (c[2] == roomNumber.ToString())
                    {
                        customerInfo = customer.ToString();
                    }
                    else
                    {
                        customerInfo = "Room is Available";
                    }
                }
                result = roomInfo + " ==> Availability status: " + customerInfo;

                return result;
            }
            catch (IOException e)
            {
                rooms.Add(e.Message);
                return "";
            }
        }

        public string Search(string text, string fileName)
        {
            IEnumerable<string> lines = new List<string>();
            string path = String.Format(@".\{0}Binary.txt", fileName);
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    string s = "";
                    while ((s = reader.ReadString()) != null)
                    {
                        lines = (File.ReadLines(path)
                           .SkipWhile(line => !line.Contains(text)));
                    }
                    foreach (string line in lines)
                    {
                        return line;
                    }
                }
                return "";
            }
            catch (IOException e)
            {
                return e.Message;
            }
        }

        public string WriteToFile(string fileName, object text)
        {
            string path = String.Format(@".\{0}Binary.txt", fileName);
            try
            {
                BinaryWriter bw;
                FileStream fs;
                if (!File.Exists(path))
                {
                    fs = new FileStream(path, FileMode.CreateNew);
                }
                else
                {
                    fs = new FileStream(path, FileMode.Append);
                }
                    using (bw = new BinaryWriter(fs))
                {
                    if(text.GetType() == typeof(Customer))
                    {
                        Customer customer =  (Customer)text;
                        bw.Write(customer.Id);
                        bw.Write(customer.Name);
                        bw.Write(customer.RoomNumber);
                        bw.Write(customer.ArrivalDate.ToString());
                        bw.Write(customer.LengthOfStay);
                        return "Success";
                    } else if(text.GetType() == typeof(Room))
                    {
                        Room room = (Room)text;
                        bw.Write(room.RoomNumber);
                        bw.Write(room.AreaType);
                        bw.Write(room.Description);
                        bw.Write(room.Price);
                        return "Success";
                    } else if(text.GetType() == typeof(Hotel))
                    {
                        Hotel hotel = (Hotel)text;
                        bw.Write(hotel.Name);
                        bw.Write(hotel.Address);
                        bw.Write(hotel.ConstructionDate.ToString());
                        bw.Write(hotel.Star);
                        return "Success";
                    }
                    return "Not exist";

                }
                
            }
            catch (IOException e)
            {
                return e.Message;
            }
        }

    }
}
