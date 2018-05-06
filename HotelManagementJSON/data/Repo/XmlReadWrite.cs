using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using HotelManagementJSON.Models;

namespace HotelManagementJSON.data
{
    public class XmlReadWrite : IRepository
    {
        public List<string> GetAll(string fileName)
        {
            string path = String.Format(@".\{0}Xml.xml", fileName);
    
            if(fileName == "Customer")
            {
                return ReadXML<Customer>(path);
            }
            else if(fileName == "Hotel")
            {
                return ReadXML<Hotel>(path);
            }
            else
            {
                return ReadXML<Room>(path);
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
            return WriteXML(text, path);
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
            return "File length: " + new FileInfo(filePathName).Length;
        }
        private List<string> ReadXML<T>(string FileName)
        {
            List<string> lists = new List<string>();

            // Create an instance of the XmlSerializer specifying type and namespace.
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            // A FileStream is needed to read the XML document.
            FileStream fs = new FileStream(FileName, FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);

            // Declare an object variable of the type to be deserialized.
            T i;

            // Use the Deserialize method to restore the object's state.
            i = (T)serializer.Deserialize(reader);
            fs.Close();
            lists.Add(i.ToString());
            return lists;
        }
    }
}
