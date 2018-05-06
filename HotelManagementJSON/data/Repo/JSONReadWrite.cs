using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using HotelManagementJSON.Models;

namespace HotelManagementJSON.data
{
    class JSONReadWrite : IRepository
    {
        private List<string> readJson<T>(T type, string fileName)
        {
            string path = String.Format(@".\{0}Json.json", fileName);
            StreamReader reader = new StreamReader(path);
            string jsonData = reader.ReadToEnd();
            reader.Close();
            List<string> lists = new List<string>();
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(jsonData)))
            {
                // Deserialization from JSON  
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(type.GetType());
                T customer = (T)deserializer.ReadObject(ms);
                lists.Add(customer.ToString());
                return lists;
            }
        }

        public List<string> GetAll(string fileName)
        {
            
            if(fileName == "Customer")
            {
                Customer customer = new Customer();
                return readJson(customer, fileName);
            }else if(fileName == "Room")
            {
                Room room = new Room();
                return readJson(room, fileName);
            }
            else
            {
                Hotel hotel = new Hotel();
                return readJson(hotel, fileName);
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
            string path = String.Format(@".\{0}Json.json", fileName);
            try
            {
                var serializingSettings = new DataContractJsonSerializerSettings();
                serializingSettings.UseSimpleDictionaryFormat = true;
                serializingSettings.DateTimeFormat = new DateTimeFormat("d.M.yyyy");

                DataContractJsonSerializer ser = new DataContractJsonSerializer(text.GetType());

                FileStream fileWriter = new FileStream(path, FileMode.OpenOrCreate);
                ser.WriteObject(fileWriter, text);
                fileWriter.Close();
                
                return "Success";
            }
            catch(IOException e)
            {
                return e.Message;
            }
        }
    }
}
