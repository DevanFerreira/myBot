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
    public class cFrame : cDocument
    {
        private Frame obj;

        public cFrame(Frame baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }

        public cElement FrameElement
        {
            get { return new cElement(obj.FrameElement); }
        }

        public virtual string Id
        {
            get { return obj.Id; }
        }

        public virtual string Name
        {
            get { return obj.Name; }
        }

        public virtual void SetAttributeValue(string attr, string value)
        {
            obj.SetAttributeValue(attr, value);
        }
    }
}
