using System;
using System.Collections.Generic;

namespace HotelManagementXML.data
{
    public interface IRepository
    {
        string WriteToFile(string fileName, object text);
        string Search(string text, string fileName);
        List<string> GetAll(string fileName);
        List<string> GetAvailableRooms(string roomFile, string customerFile);
        string GetRoomInfo(int roomNumber);

    }
}
