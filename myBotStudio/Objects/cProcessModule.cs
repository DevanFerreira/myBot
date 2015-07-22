using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBotStudio.Objects
{
    [MoonSharpUserData]
    public class cProcessModule
    {
        private ProcessModule obj;

        public cProcessModule(ProcessModule ele)
        {
            obj = ele;
        }

        public string FileName
        {
            get { return obj.FileName; }
        }

        public string FileVersionInfo
        {
            get { return obj.FileVersionInfo.ToString(); }
        }

        public string ModuleName
        {
            get { return obj.ModuleName; }
        }
    }
}
