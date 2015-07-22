using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;
using WatiN.Core.Native.Windows;

namespace myBot.Controls
{
    [MoonSharpUserData]
    public class cIE : cBrowser
    {
        private IE obj;

        #region Initialization

        public cIE()
            : this(new IE(true))
        {

        }

        public cIE(IE baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }

        #endregion

        #region Properties

        public cHtmlDialog[] HtmlDialogs
        {
            get
            {
                HtmlDialogCollection links = obj.HtmlDialogs;
                List<cHtmlDialog> newLinks = new List<cHtmlDialog>();

                for (int i = 0; i < links.Count - 1; i++)
                    newLinks.Add(new cHtmlDialog(links[i]));

                return newLinks.ToArray();
            }
        }

        public cHtmlDialog[] HtmlDialogsNoWait
        {
            get
            {
                HtmlDialogCollection links = obj.HtmlDialogsNoWait;
                List<cHtmlDialog> newLinks = new List<cHtmlDialog>();

                for (int i = 0; i < links.Count - 1; i++)
                    newLinks.Add(new cHtmlDialog(links[i]));

                return newLinks.ToArray();
            }
        }

        public bool Visible
        {
            get { return obj.Visible; }
            set { obj.Visible = value; }
        }

        #endregion

        #region Functions

        public void GoTo(string url)
        {
            obj.GoTo(url);
        }

        public void GoToNoWait(string url)
        {
            obj.GoToNoWait(url);
        }

        public override void SetStyle(NativeMethods.WindowShowStyle style)
        {
            obj.ShowWindow(style);
        }

        public void ClearCache()
        {
            obj.ClearCache();
        }

        public void ClearCookies(string url = "")
        {
            if (String.IsNullOrWhiteSpace(url))
                obj.ClearCookies();
            else
                obj.ClearCookies(url);
        }

        public string GetCookie(string url, string name)
        {
            return obj.GetCookie(url, name);
        }

        public override void Reopen()
        {
            obj.Reopen();
        }

        public void SetCookie(string url, string data)
        {
            obj.SetCookie(url, data);
        }

        public override void WaitForComplete(int timeout = 0)
        {
            if (timeout > 0)
                obj.WaitForComplete(timeout);
            else
                obj.WaitForComplete();
        }

        #endregion
    }
}
