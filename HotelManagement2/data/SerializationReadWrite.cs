using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.data
{
    public class SerializationReadWrite : IRepository
    {
        public List<string> GetAll(string fileName)
        {
            List<string> allLines = new List<string>();

            try
            {
                string path = String.Format(@".\{0}Seriliz.txt", fileName);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream fs = new FileStream(path, FileMode.Open);
                using (BinaryReader binaryReader = new BinaryReader(fs))
                {

                    if (fileName == "Customer")
                    {
                        Customer customer = new Customer();
                        while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                        {
                            customer = (Customer)binaryFormatter.Deserialize(fs);
                            allLines.Add(customer.Id + "," + customer.Name + "," + customer.RoomNumber + "," + customer.ArrivalDate + "," + customer.LengthOfStay);
                        }
                    }
                    else if (fileName == "Room")
                    {
                        Room room = new Room();
                        while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                        {
                            room = (Room)binaryFormatter.Deserialize(fs);
                            allLines.Add(room.RoomNumber + "," + room.AreaType + "," + room.Description + "," + room.Price);
                        }

                    }
                    else if (fileName == "Hotel")
                    {
                        Hotel hotel = new Hotel();
                        while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                        {
                            hotel = (Hotel)binaryFormatter.Deserialize(fs);
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
            string roomPath = String.Format(@".\{0}Seriliz.txt", roomFile);
            string customerPath = String.Format(@".\{0}Seriliz.txt", customerFile);
            try
            {
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
            string roomPath = String.Format(@".\{0}Seriliz.txt", "Room");
            string customerPath = String.Format(@".\{0}Seriliz.txt", "Customer");
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
            lines = GetAll(fileName);
            string path = String.Format(@".\{0}Seriliz.txt", fileName);
            try
            {
                foreach(string line in lines)
                {
                    if (line.Contains(text))
                    {
                        return line;
                    }
                    
                }
                return "Not Exist";
            }
            catch (IOException e)
            {
                return e.Message;
            }
        }

        public string WriteToFile(string fileName, object text)
        {
            string path = String.Format(@".\{0}Seriliz.txt", fileName);
            try
            {
                BinaryWriter bw;
                FileStream fs;
                BinaryFormatter binaryFormatter = new BinaryFormatter();
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
                    if (text.GetType() == typeof(Customer))
                    {
                        Customer customer = (Customer)text;
                        binaryFormatter.Serialize(fs, customer);
                        fs.Flush();
                        fs.Close();
                        return "Success";
                    }
                    else if (text.GetType() == typeof(Room))
                    {
                        Room room = (Room)text;
                        binaryFormatter.Serialize(fs, room);
                        fs.Flush();
                        fs.Close();
                        return "Success";
                    }
                    else if (text.GetType() == typeof(Hotel))
                    {
                        Hotel hotel = (Hotel)text;
                        binaryFormatter.Serialize(fs, hotel);
                        fs.Flush();
                        fs.Close();
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
