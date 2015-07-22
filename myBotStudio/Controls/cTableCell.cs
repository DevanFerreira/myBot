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
    public class cTableCell : cElementContainer<TableCell>
    {
        private TableCell obj;

        public cTableCell(TableCell baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }

        public cTable ParentTable
        {
            get { return new cTable(obj.ContainingTable); }
        }

        public cTableBody ParentTableBody
        {
            get { return new cTableBody(obj.ContainingTableBody); }
        }

        public cTableRow ParentTableRow
        {
            get { return new cTableRow(obj.ContainingTableRow); }
        }

        public int Index
        {
            get { return obj.Index; }
        }
    }
}
