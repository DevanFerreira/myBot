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
    public class cBody : cElementContainer<Body>
    {
        public cBody(Body baseObject)
            : base(baseObject)
        {
            
        }
    }
}
