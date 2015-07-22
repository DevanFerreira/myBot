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
    public class cForm : cElementContainer<Form>
    {
        private Form obj;

        public cForm(Form baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }

        public virtual void Submit()
        {
            obj.Submit();
        }
    }
}
