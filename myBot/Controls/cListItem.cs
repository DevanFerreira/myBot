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
    public class cListItem : cElementContainer<ListItem>
    {
        private ListItem obj;

        public cListItem(ListItem baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }
    }
}
