using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;

namespace myBotStudio.Controls
{
    [MoonSharpUserData]
    public class cHtmlDialog : cDomContainer
    {
        private HtmlDialog obj;

        public cHtmlDialog(HtmlDialog ele)
            : base(ele)
        {
            obj = ele;
        }

        public virtual bool Exists
        {
            get { return obj.Exists; }
        }

        public virtual void Close()
        {
            obj.Close();
        }

        public override void WaitForComplete(int timeout)
        {
            obj.WaitForComplete(timeout);
        }

        public virtual void WaitUntilClosed(int timeout = 0)
        {
            if (timeout > 0)
                obj.WaitUntilClosed(timeout);
            else
                obj.WaitUntilClosed();
        }
    }
}
