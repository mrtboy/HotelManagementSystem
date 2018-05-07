using HotelManagementXML.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HotelManagementXML.data
{
    public class XMLTextManipulation : IRepository
    {
        public List<string> GetAll(string fileName)
        {
            throw new NotImplementedException();
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
            string filePathName = String.Format(@".\{0}Xml.xml", fileName);
            FileInfo fileInfo = new FileInfo(filePathName);
            if (!fileInfo.Exists)
            {

                try
                {
                    File.CreateText(filePathName).Close();
                    return "";
                }
                catch (FileNotFoundException)
                {
                    return "";
                }
            }
            else
            {
                //Here we write the XML tree to the file only if the file is empty
                if (fileInfo.Length == 0)
                    WriteXML(filePathName, text);
                //Here we add a new element to the existing XML tree.

                //AddNewElement(filePathName, text);
                return "";
            }
            
        
        }
    

        public string WriteXML(string filePathName, object text)
        {
            Customer customer = new Customer();
            customer = (Customer)text;
            //Here we use the XmlTextWriter to open a new XML file
            XmlTextWriter xmlTextWriter = new
           XmlTextWriter(filePathName, System.Text.Encoding.UTF8);


            xmlTextWriter.Formatting = Formatting.Indented;
            xmlTextWriter.WriteStartDocument();
            xmlTextWriter.WriteStartElement("customers");
            xmlTextWriter.WriteStartElement("customer");
            xmlTextWriter.WriteElementString("id", customer.Id.ToString() );
            xmlTextWriter.WriteElementString("name", customer.Name);
            xmlTextWriter.WriteElementString("lenghOfStar", customer.LengthOfStay.ToString());
            xmlTextWriter.WriteElementString("roomNumber", customer.RoomNumber.ToString());
            xmlTextWriter.WriteElementString("address", customer.Address);
            //xmlTextWriter.WriteElementString("id", customer.);
            xmlTextWriter.WriteElementString("name", customer.Name);
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.WriteStartElement("employee");

            xmlTextWriter.WriteElementString("name", "Farhad");
            xmlTextWriter.WriteElementString("job", "Software Designer");
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.WriteEndDocument();

            xmlTextWriter.Flush();
            xmlTextWriter.Close();
            return GetFileInfo(filePathName);
        }

        public string GetFileInfo(string filePathName)
        {
            //Here we create a FileInfo object
            FileInfo fileInfo = new FileInfo(filePathName);
            //Here we return the file path and its length.
            return Path.GetFullPath(filePathName) + " was written succefully.File size: " + fileInfo.Length + ".";
        }

        public string AppendElement(string filePathName)
        {
            XmlTextReader xmlTextReader = new
           XmlTextReader(filePathName);
            xmlTextReader.WhitespaceHandling =
           WhitespaceHandling.None;
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlTextReader);
            xmlTextReader.Close();
            XmlElement newEmpElement =
           xmlDocument.CreateElement("employee");
            newEmpElement.SetAttribute("id", "e5000");
            XmlElement newNameElement =
           xmlDocument.CreateElement("name");
            newNameElement.InnerText = "Barbara";
            newEmpElement.AppendChild(newNameElement);
            XmlElement newJobElement =
           xmlDocument.CreateElement("job");
            newJobElement.InnerText = "Software Designer";
            newEmpElement.AppendChild(newJobElement);

            XmlNode rootNode = xmlDocument.DocumentElement;
            //
            xmlDocument.GetElementById("employees").AppendChild(newEmpElement);

            rootNode.AppendChild(newEmpElement);
            xmlDocument.Save(filePathName);
            return GetFileInfo(filePathName);
        }

        public string AddNewElement(string filePathName, string parent, object text)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePathName);
            XmlNode employeeNode =
           xmlDocument.CreateNode(XmlNodeType.Element, "employee", null);
            XmlAttribute attribute =
           xmlDocument.CreateAttribute("id");
            attribute.Value = "e8000";
            employeeNode.Attributes.Append(attribute);
            XmlNode nameNode =
           xmlDocument.CreateNode(XmlNodeType.Element, "name", null);
            nameNode.InnerText = "Arash";
            employeeNode.AppendChild(nameNode);
            XmlNode jobNode =
           xmlDocument.CreateNode(XmlNodeType.Element, "job", null);
            jobNode.InnerText = "Software developer";
            employeeNode.AppendChild(jobNode);

            xmlDocument.SelectSingleNode("//" + parent).AppendChild(employeeNode);

            xmlDocument.Save(filePathName);
            return GetFileInfo(filePathName);
        }
    }
}
