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
    public class cSpan : cElementContainer<Span>
    {
        private Span obj;

        public cSpan(Span baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }
    }
}
