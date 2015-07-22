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
    public class cFormCollection : cBaseElementCollection<Form, FormCollection, cForm>
    {
        public cFormCollection(FormCollection ele)
            : base(ele)
        {

        }
    }
}
