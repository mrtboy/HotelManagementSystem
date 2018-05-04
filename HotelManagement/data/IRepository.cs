using System;
using System.Collections.Generic;

namespace HotelManagement.data
{
    public interface IRepository
    {
        string WriteToFile(string fileName, object text);
        string ReadFromFile(string fileName);
        string Search(string text, string fileName);
        List<String> GetAll(string fileName);

    }
}
