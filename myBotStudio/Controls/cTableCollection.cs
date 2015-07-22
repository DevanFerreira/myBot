using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;

using Table = WatiN.Core.Table;

namespace myBotStudio.Controls
{
    [MoonSharpUserData]
    public class cTableCollection : cBaseElementCollection<Table, TableCollection, cTable>
    {
        public cTableCollection(TableCollection col)
            : base(col)
        {

        }
    }
}
