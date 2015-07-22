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
    public class cSpanCollection : cBaseElementCollection<Span, SpanCollection, cSpan>
    {
        public cSpanCollection(SpanCollection ele)
            : base(ele)
        {

        }
    }
}
