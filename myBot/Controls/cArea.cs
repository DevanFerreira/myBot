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
    public class cArea : cElement<Area>
    {
        private Area obj;

        public cArea(Area baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }

        public virtual string AltText
        {
            get { return obj.Alt; }
        }

        public virtual string Coordinates
        {
            get { return obj.Coords; }
        }

        public virtual string Shape
        {
            get { return obj.Shape; }
        }

        public virtual string Url
        {
            get { return obj.Url; }
        }
    }
}
