using MoonSharp.Interpreter;
using myBotStudio.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;

namespace myBotStudio.Controls
{
    [MoonSharpUserData]
    public class cComponent
    {
        private Component obj;

        public cComponent(Component ele)
        {
            obj = ele;
        }

        public string Description
        {
            get { return obj.Description; }
        }

        public virtual string GetAttribute(string attr)
        {
            return obj.GetAttributeValue(attr);
        }

        public virtual bool Matches(DynValue findBy, DynValue s1, DynValue s2)
        {
            return obj.Matches(Helpers.ParseConstraint(findBy, s1, s2));
        }
    }
}
