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
    public class cRadioButtonCollection : cBaseElementCollection<RadioButton, RadioButtonCollection, cRadioButton>
    {
        public cRadioButtonCollection(RadioButtonCollection ele)
            : base(ele)
        {

        }
    }
}
