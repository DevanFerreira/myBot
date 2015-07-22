using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace myBot.Objects
{
    [MoonSharpUserData]
    public class cProcess
    {
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        private Process obj;

        public cProcess(Process ele)
        {
            obj = ele;
        }

        public void Close()
        {
            obj.Close();
            obj.Dispose();
        }

        public void CloseMainWindow()
        {
            obj.CloseMainWindow();
            obj.Dispose();
        }

        public void Kill()
        {
            obj.Kill();
            obj.Dispose();
        }

        public void Refresh()
        {
            obj.Refresh();
        }

        public bool Start()
        {
            return obj.Start();
        }

        public void WaitForExit(int ms = 0)
        {
            if (ms > 0)
                obj.WaitForExit(ms);
            else
                obj.WaitForExit();
        }

        public bool WaitForInputIdle(int ms = 0)
        {
            if (ms > 0)
                return obj.WaitForInputIdle(ms);
            else
                return obj.WaitForInputIdle();
        }

        public int BasePriority
        {
            get { return obj.BasePriority; }
        }

        public int ExitCode
        {
            get { return obj.ExitCode; }
        }

        public int HandleCount
        {
            get { return obj.HandleCount; }
        }

        public bool HasExited
        {
            get { return obj.HasExited; }
        }

        public int Id
        {
            get { return obj.Id; }
        }

        public string MachineName
        {
            get { return obj.MachineName; }
        }

        public cProcessModule MainModule
        {
            get { return new cProcessModule(obj.MainModule); }
        }

        public string MainWindowTitle
        {
            get { return obj.MainWindowTitle; }
        }

        public cProcessModule[] Modules
        {
            get
            {
                ProcessModuleCollection col = obj.Modules;
                List<cProcessModule> ncol = new List<cProcessModule>();

                for (int i = 0; i < col.Count; i++)
                    ncol.Add(new cProcessModule(col[i]));

                return ncol.ToArray();
            }
        }

        public string ProcessName
        {
            get { return obj.ProcessName; }
        }

        public bool IsResponding
        {
            get { return obj.Responding; }
        }

        public int SessionId
        {
            get { return obj.SessionId; }
        }

        public cProcessStartInfo StartInfo
        {
            get { return new cProcessStartInfo(obj.StartInfo); }
            set { obj.StartInfo = value.obj; }
        }

        public void BringToFront()
        {
            SetForegroundWindow(obj.MainWindowHandle);
        }
    }
}
