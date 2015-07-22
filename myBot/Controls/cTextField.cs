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
    public class cTextField : cElement
    {
        private TextField obj;

        public cTextField(TextField baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }

        public void Type(string text)
        {
            obj.TypeText(text);
        }
    }
}
