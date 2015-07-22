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
    public class cLink : cElementContainer<Link>
    {
        private Link obj;

        public cLink(Link baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }

        public virtual string Url
        {
            get { return obj.Url; }
        }
    }
}
