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
    public class cRadioCheck<T> : cElement<T>
        where T : Element
    {
        private RadioCheck<T> obj;

        public cRadioCheck(RadioCheck<T> baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }

        public virtual bool Checked
        {
            get { return obj.Checked; }
            set { obj.Checked = value; }
        }
    }
}
