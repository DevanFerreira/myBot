using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;

namespace myBot.Controls
{
    [MoonSharpUserData]
    public class cDomContainer : cDocument
    {
        private DomContainer obj;

        public cDomContainer(DomContainer baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }

        public virtual void CapturePageToFile(string file)
        {
            obj.CaptureWebPageToFile(file);
        }

        public virtual void WaitForComplete(int timeout = 0)
        {
            if (timeout > 0)
                obj.WaitForComplete(timeout);
            else
                obj.WaitForComplete();
        }
    }
}
