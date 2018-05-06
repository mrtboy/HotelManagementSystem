using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using HotelManagementXML.Models;

namespace HotelManagementXML.data
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
            throw new NotImplementedException();
        }

        public string GetRoomInfo(int roomNumber)
        {
            throw new NotImplementedException();
        }

        public string Search(string text, string fileName)
        {
            throw new NotImplementedException();
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
            Console.WriteLine("Reading with XmlReader");

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
