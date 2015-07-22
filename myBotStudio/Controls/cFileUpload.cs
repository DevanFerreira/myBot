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
    public class cFileUpload : cElement<FileUpload>
    {
        private FileUpload obj;

        public cFileUpload(FileUpload baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }

        public virtual string FileName
        {
            get { return obj.FileName; }
            set { obj.Set(value); }
        }
    }
}
