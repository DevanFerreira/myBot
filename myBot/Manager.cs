using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace myBot
{
    public static class Manager
    {
        private static string scriptPath = String.Empty;

        private static string exePath;
        private static string scriptsPath;
        private static string libPath;
        private static string savePath;
        private static string binPath;
        private static string firefoxPath;

        public static string ScriptPath
        {
            get { return scriptPath; }
            set { scriptPath = value; }
        }

        public static string ExePath
        {
            get
            {
                if (String.IsNullOrWhiteSpace(exePath))
                    exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\";

                return exePath;
            }
        }

        public static string ScriptsPath
        {
            get
            {
                if (String.IsNullOrWhiteSpace(scriptsPath))
                    scriptsPath = Path.Combine(ExePath, "Scripts\\");

                return scriptsPath;
            }
        }

        public static string LibsPath
        {
            get
            {
                if (String.IsNullOrWhiteSpace(libPath))
                    libPath = Path.Combine(ScriptsPath, "Common\\");

                return libPath;
            }
        }

        public static string SavesPath
        {
            get
            {
                if (String.IsNullOrWhiteSpace(savePath))
                    savePath = Path.Combine(LibsPath, "Saves\\");

                return savePath;
            }
        }

        public static string BinPath
        {
            get
            {
                if (String.IsNullOrWhiteSpace(binPath))
                    binPath = Path.Combine(ExePath, "Bin\\");

                return binPath;
            }
        }

        public static string FireFoxPath
        {
            get
            {
                if (String.IsNullOrWhiteSpace(firefoxPath))
                    firefoxPath = Path.Combine(BinPath, "FireFox\\");

                return firefoxPath;
            }
        }
    }
}
