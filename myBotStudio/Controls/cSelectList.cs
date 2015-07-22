using MoonSharp.Interpreter;
using myBotStudio.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;

namespace myBotStudio.Controls
{
    [MoonSharpUserData]
    public class cSelectList : cElement<SelectList>
    {
        private SelectList obj;

        public cSelectList(SelectList baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }

        public virtual string[] AllContents
        {
            get
            {
                StringCollection coll = obj.AllContents;
                List<string> ncoll = new List<string>();

                for (int i = 0; i < coll.Count; i++)
                    ncoll.Add(coll[i]);

                return ncoll.ToArray();
            }
        }

        public virtual bool HasSelectedItems
        {
            get { return obj.HasSelectedItems; }
        }

        public virtual bool CanSelectMultiple
        {
            get { return obj.Multiple; }
        }

        public virtual cOption[] Options
        {
            get
            {
                OptionCollection coll = obj.Options;
                List<cOption> ncoll = new List<cOption>();

                for (int i = 0; i < coll.Count; i++)
                    ncoll.Add(new cOption(coll[i]));

                return ncoll.ToArray();
            }
        }

        public virtual string SelectedItem
        {
            get { return obj.SelectedItem; }
        }

        public virtual string[] SelectedItems
        {
            get
            {
                StringCollection coll = obj.SelectedItems;
                List<string> ncoll = new List<string>();

                for (int i = 0; i < coll.Count; i++)
                    ncoll.Add(coll[i]);

                return ncoll.ToArray();
            }
        }

        public virtual cOption SelectedOption
        {
            get { return new cOption(obj.SelectedOption); }
        }

        public virtual cOption[] SelectedOptions
        {
            get
            {
                ArrayList list = obj.SelectedOptions;
                List<cOption> ops = new List<cOption>();

                for (int i = 0; i < list.Count; i++)
                    ops.Add(new cOption((Option)list[i]));

                return ops.ToArray();
            }
        }

        public virtual void ClearList()
        {
            obj.ClearList();
        }

        public virtual cOption FindOption(string text)
        {
            return new cOption(obj.Option(text));
        }

        public virtual cOption FindOption(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cOption(obj.Option(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        public void Select(string text)
        {
            obj.Select(text);
        }

        public void SelectByValue(string value)
        {
            obj.SelectByValue(value);
        }
    }
}
