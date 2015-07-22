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
    public abstract class cBaseElementCollection<TElement, TCollection, TUserData> : cBaseComponentCollection<TElement, TCollection, TUserData>
        where TElement : Element
        where TCollection : BaseElementCollection<TElement, TCollection>
        where TUserData : cElement
    {
        private BaseElementCollection<TElement, TCollection> obj;

        public cBaseElementCollection(BaseElementCollection<TElement, TCollection> ele)
            : base(ele)
        {
            obj = ele;
        }

        public virtual bool Exists(string id)
        {
            return obj.Exists(id);
        }
    }
}
