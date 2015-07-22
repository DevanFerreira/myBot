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
    public class cButton : cElement<Button>
    {
        private Button obj;

        public cButton(Button baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }

        public override string Text
        {
            get { return obj.Text; }
        }

        public virtual string Value
        {
            get { return obj.Value; }
        }
    }
}
