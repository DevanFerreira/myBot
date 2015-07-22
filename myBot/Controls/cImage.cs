using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;

namespace myBot.Controls
{
    [MoonSharpUserData]
    public class cImage : cElement<Image>
    {
        private Image obj;

        public cImage(Image baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }

        public virtual string AltText
        {
            get { return obj.Alt; }
        }

        public virtual string Source
        {
            get { return obj.Src; }
        }

        public virtual string Url
        {
            get { return obj.Uri.ToString(); }
        }
    }
}
