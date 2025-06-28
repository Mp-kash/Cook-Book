using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Logging
{
    public class Logger
    {
        private static readonly string _logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Logger.txt");
        public static void Log(string message, DateTime time)
        {
            string logEntry = $"{time}: {message}";
            int id = 1;

            if (!File.Exists(_logFilePath))
            {
                using(File.Create(_logFilePath)) { }
            }
            else
            {
                // Counts the number of lines to determine the next Id
                id = File.ReadAllLines(_logFilePath).Length + 1;
            }

            using (StreamWriter sw = File.AppendText(_logFilePath))
            {
                sw.WriteLine($"{id} - {logEntry}");
            }

        }
    }
}
