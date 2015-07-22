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
    public class cTableBody : cElementContainer<TableBody>
    {
        private TableBody obj;

        public cTableBody(TableBody baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }

        public cTable ContainingTable
        {
            get { return new cTable(obj.ContainingTable); }
        }

        public cTableRowCollection OwnTableRows
        {
            get { return new cTableRowCollection(obj.OwnTableRows); }
        }

        public cTableRow FindOwnTableRow(string id)
        {
            return new cTableRow(obj.OwnTableRow(id));
        }

        public cTableRow FindOwnTableRow(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cTableRow(obj.OwnTableRow(Helpers.ParseConstraint(findBy, s1, s2)));
        }
    }
}
