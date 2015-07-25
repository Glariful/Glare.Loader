using System;
using System.Diagnostics;
using System.IO;

namespace Glare.Loader.Data
{
    public static class Directories
    {
        public static readonly string CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public static readonly string AppDataDirectory =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Glare" +
            Environment.UserName.GetHashCode().ToString("X")) + "\\";

        
        public static readonly string AssembliesDir = Path.Combine(AppDataDirectory, "1") + "\\";
        public static readonly string CoreDirectory = Path.Combine(CurrentDirectory, "System") + "\\";
        public static readonly string LogsDir = Path.Combine(CurrentDirectory, "Logs") + "\\";

        
        public static readonly string LoaderFilePath = Path.Combine(CurrentDirectory, Process.GetCurrentProcess().ProcessName);
        public static readonly string ConfigFilePath = Path.Combine(CurrentDirectory, "config.xml");
        
    }
}
