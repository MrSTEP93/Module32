using System;
using System.IO;
using System.Threading.Tasks;

namespace Module35.Go
{
    public class Logger
    {
        public readonly string _logFileName;
        public readonly string _logFolderName;
        public readonly bool _isDateTimeNeeds;

        public Logger(string fileName) : this(Environment.CurrentDirectory, fileName, false, false) { }

        public Logger(string folderName, string fileName) : this(folderName, fileName, false, false) { }

        public Logger(string folderName, string fileName, bool isDateTimeNeeds) : this(folderName, fileName, isDateTimeNeeds, false) { }

        public Logger(string folderName, string fileName, bool isDateTimeNeeds, bool isOverwriteNeeds)
        {
            _logFolderName = folderName;
            if (folderName[^1] != '\\')
                _logFolderName += "\\";
            _logFileName = _logFolderName + fileName;
            _isDateTimeNeeds = isDateTimeNeeds;

            Directory.CreateDirectory(folderName);
            if (isOverwriteNeeds)
            {
                File.Delete(_logFileName);
            }
            //File.Create(_logFileName);
            File.AppendAllText(_logFileName, "Application started at " + DateTime.Now + "\n");
        }

        public async void Log(string message)
        {
            if (_isDateTimeNeeds)
            {
                message = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] " + message;
            }
            await File.AppendAllTextAsync(_logFileName, message + "\n");
        }
    }
}
