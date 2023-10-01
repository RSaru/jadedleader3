using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Reflection;

namespace jadedleader3.FileManager
{
    public static class Configuration
    {
        public static string ConfigureLectures()
        {
            string currentDirectory = Environment.CurrentDirectory;
            string subfolderName = "JsonFiles";  
            string fileName = "LectureStorage.json";
            string filePath = Path.Combine(currentDirectory, subfolderName, fileName);
            return filePath;
        }

        public static string ConfigureUsers()
        {
            string currentDirectory = Environment.CurrentDirectory;
            string subfolderName = "JsonFiles";
            string fileName = "UserAccounts.json";
            string filePath = Path.Combine(currentDirectory, subfolderName, fileName);
            return filePath;
        }
    }
}
