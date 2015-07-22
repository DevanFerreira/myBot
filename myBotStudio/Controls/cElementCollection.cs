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
    public class cElementCollection : cBaseElementCollection<Element, ElementCollection, cElement>
    {
        private ElementCollection obj;

        public cElementCollection(ElementCollection ele)
            : base(ele)
        {
            obj = ele;
        }

        public override DynValue this[int index]
        {
            get { return Helpers.ParseElement(obj[index - 1]); }
        }
    }

    [MoonSharpUserData]
    public class cElementCollection<TElement> : cBaseElementCollection<TElement, ElementCollection<TElement>, cElement>
        where TElement : Element
    {
        public cElementCollection(ElementCollection<TElement> ele)
            : base(ele)
        {

        }
    }
}
