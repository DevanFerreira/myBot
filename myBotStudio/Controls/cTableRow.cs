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
    public class cTableRow : cElementContainer<TableRow>
    {
        private TableRow obj;

        public cTableRow(TableRow baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }

        public cTable ParentTable
        {
            get { return new cTable(obj.ContainingTable); }
        }

        public int Index
        {
            get { return obj.Index; }
        }
    }
}
