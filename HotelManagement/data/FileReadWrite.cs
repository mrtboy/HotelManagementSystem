using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HotelManagement.data
{
    public class FileReadWrite : IRepository
    {
        public string WriteToFile(string fileName,object text)
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
            }catch(IOException e)
            {
                return e.Message;
            }

        }

        public string ReadFromFile(string fileName)
        {
            string path = String.Format(@".\{0}.txt", fileName); 
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    return s;
                }
            }
            return "";
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
            }catch(IOException e)
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
            }catch(IOException e)
            {
                allLines.Add(e.Message);
                return allLines;
            }
        }
    }
}
