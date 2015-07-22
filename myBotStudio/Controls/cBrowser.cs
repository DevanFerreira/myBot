using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;
using WatiN.Core.Native.Windows;

namespace myBotStudio.Controls
{
    [MoonSharpUserData]
    public class cBrowser : cDomContainer
    {
        private Browser obj;

        public cBrowser(Browser baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }

        public virtual bool GoBack()
        {
            return obj.Back();
        }

        public virtual void BringToFront()
        {
            obj.BringToFront();
        }

        public void Close()
        {
            obj.Close();
            obj.Dispose();

            Program.SetGlobal("Browser", DynValue.NewNil());
        }

        public virtual bool Forward()
        {
            return obj.Forward();
        }

        public virtual NativeMethods.WindowShowStyle GetStyle()
        {
            return obj.GetWindowStyle();
        }

        public virtual void GoTo(string url, bool wait = true)
        {
            if (wait)
                obj.GoTo(url);
            else
                obj.GoToNoWait(url);
        }

        public virtual void Refresh()
        {
            obj.Refresh();
        }

        public virtual void Reopen()
        {
            obj.Reopen();
        }

        public virtual void SetStyle(NativeMethods.WindowShowStyle style)
        {
            obj.ShowWindow(style);
        }

        public virtual void SetSize(int width, int height)
        {
            obj.SizeWindow(width, height);
        }
    }
}
