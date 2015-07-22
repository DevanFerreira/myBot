using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;
using myBotStudio.Managers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBotStudio.Objects
{
    [MoonSharpUserData]
    public class cProcessStartInfo
    {
        [MoonSharpVisible(false)]
        public ProcessStartInfo obj;

        public cProcessStartInfo(ProcessStartInfo ele)
        {
            obj = ele;
        }

        public string Arguments
        {
            get { return obj.Arguments; }
            set { obj.Arguments = value; }
        }

        public bool CreateNoWindow
        {
            get { return obj.CreateNoWindow; }
            set { obj.CreateNoWindow = value; }
        }

        public string Domain
        {
            get { return obj.Domain; }
            set { obj.Domain = value; }
        }

        public bool ShowErrorDialog
        {
            get { return obj.ErrorDialog; }
            set { obj.ErrorDialog = value; }
        }

        public string FileName
        {
            get { return obj.FileName; }
            set { obj.FileName = value; }
        }

        public bool LoadUserProfile
        {
            get { return obj.LoadUserProfile; }
            set { obj.LoadUserProfile = value; }
        }

        public string Username
        {
            get { return obj.UserName; }
            set { obj.UserName = value; }
        }

        public bool UseShellExecute
        {
            get { return obj.UseShellExecute; }
            set { obj.UseShellExecute = value; }
        }

        public string Verb
        {
            get { return obj.Verb; }
            set { obj.Verb = value; }
        }

        public string[] Verbs
        {
            get { return obj.Verbs; }
        }

        public ProcWindowStyle WindowStyle
        {
            get
            {
                switch (obj.WindowStyle)
                {
                    case ProcessWindowStyle.Maximized:
                        return ProcWindowStyle.Maximized;

                    case ProcessWindowStyle.Minimized:
                        return ProcWindowStyle.Minimized;

                    case ProcessWindowStyle.Hidden:
                        return ProcWindowStyle.Hidden;

                    default:
                    case ProcessWindowStyle.Normal:
                        return ProcWindowStyle.Normal;
                }
            }
            set
            {
                switch (value)
                {
                    case ProcWindowStyle.Maximized:
                        obj.WindowStyle = ProcessWindowStyle.Maximized;
                        break;

                    case ProcWindowStyle.Minimized:
                        obj.WindowStyle = ProcessWindowStyle.Minimized;
                        break;

                    case ProcWindowStyle.Hidden:
                        obj.WindowStyle = ProcessWindowStyle.Hidden;
                        break;

                    default:
                    case ProcWindowStyle.Normal:
                        obj.WindowStyle = ProcessWindowStyle.Normal;
                        break;
                }
            }
        }

        public string WorkingDirectory
        {
            get { return obj.WorkingDirectory; }
        }

        public cProcess Start()
        {
            return new cProcess(Process.Start(obj));
        }
    }
}
