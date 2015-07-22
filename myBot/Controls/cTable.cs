using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Table = WatiN.Core.Table;

namespace myBot.Controls
{
    [MoonSharpUserData]
    public class cTable : cElementContainer<Table>
    {
        private Table obj;

        public cTable(Table baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }

        public cTableRow FindRow(string text, int column)
        {
            return new cTableRow(obj.FindRow(text, column));
        }
    }
}
