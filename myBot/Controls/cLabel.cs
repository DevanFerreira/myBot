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
    public class cLabel : cElementContainer<Label>
    {
        private Label obj;

        public cLabel(Label baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }

        public virtual string AccessKey
        {
            get { return obj.AccessKey; }
        }

        public virtual string For
        {
            get { return obj.For; }
        }
    }
}
