using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HotelManagementJSON.data
{
    public class FileReadWrite : IRepository
    {
        public string WriteToFile(string fileName, object text)
        {
            try
            {
                string path = String.Format(@".\{0}.txt", fileName);
                StreamWriter sw;
                // This text is added only once to the file.
                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    using (sw = File.CreateText(path))
                    {
                        sw.WriteLine(text.ToString());
                        sw.Close();
                    }
                }
                else
                {
                    using (sw = File.AppendText(path))
                    {
                        sw.WriteLine(text);
                        sw.Close();
                    }

                }
                return "Seucces";
            }
            catch (IOException e)
            {
                return e.Message;
            }

        }

        public string Search(string text, string fileName)
        {
            IEnumerable<string> lines = new List<string>();
            string path = String.Format(@".\{0}.txt", fileName);
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
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

        public List<String> GetAll(string fileName)
        {
            List<string> allLines = new List<string>();
            try
            {
                string path = String.Format(@".\{0}.txt", fileName);
                string[] readText = File.ReadAllLines(path);
                foreach (string s in readText)
                {
                    allLines.Add(s);
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
            List<string> customers = new List<string>();
            List<string> rooms = new List<string>();
            List<string> availableRooms = new List<string>();
            try
            {
                string path = String.Format(@".\{0}.txt", customerFile);
                string[] readText = File.ReadAllLines(path);
                foreach (string c in readText)
                {
                    customers.Add(c);
                }
                
                string pathRoom = String.Format(@".\{0}.txt", roomFile);
                string[] readTextRoom = File.ReadAllLines(pathRoom);
                foreach (string r in readTextRoom)
                {
                    rooms.Add(r);
                }

                //Check room Number in Room file and Room Number in Customer File
                foreach (string room in rooms)
                {
                    string[] r = room.Split(',');
                    foreach (string customer in customers)
                    {
                        string[] c = customer.Split(',');
                        if (r[0] != c[3])
                        {
                            availableRooms.Add(room);
                        }
                    }
                }

                return availableRooms;
            }
            catch (IOException e)
            {
                rooms.Add(e.Message);
                return rooms;
            }

        }

        public string GetRoomInfo(int roomNumber)
        {
            List<string> customers = new List<string>();
            List<string> rooms = new List<string>();
            List<string> availableRooms = new List<string>();
            string roomInfo = "";
            string customerInfo = "";
            string result = "";
            try
            {
                string path = String.Format(@".\{0}.txt", "Customer");
                string[] readText = File.ReadAllLines(path);
                foreach (string s in readText)
                {
                    customers.Add(s);
                }


                string pathRoom = String.Format(@".\{0}.txt", "Room");
                string[] readTextRoom = File.ReadAllLines(pathRoom);
                foreach (string s in readText)
                {
                    rooms.Add(s);
                }

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
                    if (c[3] == roomNumber.ToString())
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
    }
}
