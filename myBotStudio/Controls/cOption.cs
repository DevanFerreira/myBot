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
    public class cOption : cElement<Option>
    {
        private Option obj;

        public cOption(Option ele)
            : base(ele)
        {
            obj = ele;
        }

        public virtual bool SelectedByDefault
        {
            get { return obj.DefaultSelected; }
        }

        public virtual int Index
        {
            get { return obj.Index; }
        }

        public virtual cSelectList ParentSelectList
        {
            get { return new cSelectList(obj.ParentSelectList); }
        }

        public virtual bool Selected
        {
            get { return obj.Selected; }
        }

        public virtual string Value
        {
            get { return obj.Value; }
        }

        public virtual void Clear(bool wait = true)
        {
            if (wait)
                obj.Clear();
            else
                obj.ClearNoWait();
        }

        public virtual void Select(bool wait = true)
        {
            if (wait)
                obj.Select();
            else
                obj.SelectNoWait();
        }
    }
}
