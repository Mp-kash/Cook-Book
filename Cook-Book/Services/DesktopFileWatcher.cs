using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cook_Book.Services
{
    public class DesktopFileWatcher
    {
        private static readonly Lazy<DesktopFileWatcher> _instance = new(()=> new DesktopFileWatcher());
        public static DesktopFileWatcher Instance => _instance.Value;
        public static bool CurrentFileStatus { get; set; }
        private readonly BackgroundWorker _fileCheckWorker;

        //Observer design pattern: (publisher)
        public event Action<bool>? OnFileStatusChanged;

        private DesktopFileWatcher()
        {
            _fileCheckWorker = new BackgroundWorker();
            _fileCheckWorker.DoWork += FileCheckWorker_DoWork;
            _fileCheckWorker.RunWorkerAsync();
        }

        private void FileCheckWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ShoppingList2.txt");

            CurrentFileStatus = false;
            while (true)
            {
                bool fileExists = File.Exists(filePath);
                if(CurrentFileStatus != fileExists)
                {
                    FileStatusChanged(fileExists);
                    CurrentFileStatus = fileExists;
                }
                Thread.Sleep(5000); 
            }
        }

        private void FileStatusChanged(bool fileExists)
        {
            if(OnFileStatusChanged != null)
            {
                OnFileStatusChanged.Invoke(fileExists);
            }
        }
    }
}
