using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using HotelManagementXML.Models;

namespace HotelManagementXML.data
{
    public class XmlReadWrite : IRepository
    {
        public List<string> GetAll(string fileName)
        {
            string path = String.Format(@".\{0}Xml.xml", fileName);
            List<string> lists = new List<string>();
            if (fileName == "Customer")
            {
                List<Customer> customers= ReadXML<List<Customer>>(path);
                foreach (Customer c in customers)
                    lists.Add(c.ToString());
                return lists;
            }
            else if (fileName == "Hotel")
            {
                List<Hotel> hotels = ReadXML<List<Hotel>>(path);
                foreach (Hotel h in hotels)
                    lists.Add(h.ToString());
                return lists;
            }
            else
            {
                List<Room> rooms = ReadXML<List<Room>>(path);
                foreach (Room r in rooms)
                    lists.Add(r.ToString());
                return lists;
            }
            return null;

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
                        if (r[0] != c[3])
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
                foreach (string line in lines)
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
            string path = String.Format(@".\{0}Xml.xml", fileName);
            
            if (fileName == "Customer")
            {
                List<Customer> customers = new List<Customer>();
                if (File.Exists(path))
                {
                    customers = ReadXML<List<Customer>>(path);
                }
               
                customers.Add((Customer)text);
                return WriteXML<List<Customer>>(customers, path);
                
            } else if (fileName == "Room")
            {
                List<Room> rooms = new List<Room>();
                if (File.Exists(path))
                {
                    rooms = ReadXML<List<Room>>(fileName);
                }
                rooms.Add((Room)text);
                return WriteXML<List<Room>>(rooms, path);
            }
            else
            {
                List<Hotel> hotels = new List<Hotel>();
                if (File.Exists(path))
                {
                    hotels = ReadXML<List<Hotel>>(fileName);
                }
                hotels.Add((Hotel)text);
                return WriteXML<List<Hotel>>(hotels, path);
            }

            
        }

        private string WriteXML<T>(T type, string filePathName)
        {
            if (type == null)
                return "Invalid data type!";
            XmlSerializer serializer = new XmlSerializer(type.GetType());
            XmlWriter xmlWriter = XmlWriter.Create(filePathName, new XmlWriterSettings()
            {
                OmitXmlDeclaration = true,
                ConformanceLevel = ConformanceLevel.Auto,
                Indent = true

            });
            serializer.Serialize(xmlWriter, type);
            xmlWriter.Close();
            return "File length: " + new
           FileInfo(filePathName).Length;
        }
        private T ReadXML<T>(string FileName)
        {
            List<string> lists = new List<string>();
       
            using (var stream = System.IO.File.OpenRead(FileName))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stream);
            }
               
        }
    }
}
