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
    public class cStyle
    {
        private Style obj;

        public cStyle(Style ele)
        {
            obj = ele;
        }

        public string BackgroundColor
        {
            get { return obj.BackgroundColor.ToName; }
        }

        public string Color
        {
            get { return obj.Color.ToName; }
        }

        public string Css
        {
            get { return obj.CssText; }
        }

        public string Display
        {
            get { return obj.Display; }
        }

        public string FontFamily
        {
            get { return obj.FontFamily; }
        }

        public string FontSize
        {
            get { return obj.FontSize; }
        }

        public string FontStyle
        {
            get { return obj.FontStyle; }
        }

        public int Height
        {
            get { return Convert.ToInt32(obj.Height); }
        }
    }
}
