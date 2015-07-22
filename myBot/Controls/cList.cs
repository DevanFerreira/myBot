using MoonSharp.Interpreter;
using myBot.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;

namespace myBot.Controls
{
    [MoonSharpUserData]
    public class cList : cElementContainer<List>
    {
        private List obj;

        public cList(List baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }

        public virtual bool IsOrdered
        {
            get { return obj.IsOrdered; }
        }

        public virtual cListItem[] OwnListItems
        {
            get
            {
                ListItemCollection coll = obj.OwnListItems;
                List<cListItem> ncoll = new List<cListItem>();

                for (int i = 0; i < coll.Count; i++)
                    ncoll.Add(new cListItem(coll[i]));

                return ncoll.ToArray();
            }
        }

        public cListItem FindOwnListItem(string id)
        {
            return new cListItem(obj.OwnListItem(id));
        }

        public cListItem FindOwnListItem(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cListItem(obj.OwnListItem(Helpers.ParseConstraint(findBy, s1, s2)));
        }
    }
}
