using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;
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
    public class cElement : cComponent
    {
        private Element obj;

        [MoonSharpVisible(false)]
        public Element _base
        {
            get { return obj; }
            set { obj = value; }
        }

        public cElement(Element ele)
            : base(ele)
        {
            obj = ele;
        }

        #region Properties

        public virtual string Class
        {
            get { return obj.ClassName; }
        }

        public virtual bool Loaded
        {
            get { return obj.Complete; }
        }

        public virtual cDomContainer DomContainer
        {
            get { return new cDomContainer(obj.DomContainer);}
        }

        public virtual bool Enabled
        {
            get { return obj.Enabled; }
        }

        public virtual bool Exists
        {
            get { return obj.Exists; }
        }

        public virtual string Id
        {
            get { return obj.Id; }
        }

        public virtual string IdOrName
        {
            get { return obj.IdOrName; }
        }

        public virtual string InnerHtml
        {
            get { return obj.InnerHtml; }
        }

        public virtual string Name
        {
            get { return obj.Name; }
        }

        public virtual cElement NextSibline
        {
            get { return new cElement(obj.NextSibling); }
        }

        public virtual string OuterHtml
        {
            get { return obj.OuterHtml; }
        }

        public virtual string OuterText
        {
            get { return obj.OuterText; }
        }

        public virtual cElement Parent
        {
            get { return new cElement(obj.Parent); }
        }

        public virtual cElement PreviousSibling
        {
            get { return new cElement(obj.PreviousSibling); }
        }

        public virtual cStyle Style
        {
            get { return new cStyle(obj.Style); }
        }

        public virtual string Tag
        {
            get { return obj.TagName; }
        }

        public virtual string Text
        {
            get { return obj.Text; }
        }

        public virtual string TextAfter
        {
            get { return obj.TextAfter; }
        }

        public virtual string TextBefore
        {
            get { return obj.TextBefore; }
        }

        public virtual string Title
        {
            get { return obj.Title; }
        }

        public bool Visible
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(Style.Display) && String.Equals(Style.Display, "none"))
                    return false;

                return true;
            }
        }

        #endregion

        #region Functions

        public virtual DynValue Ancestor(string tag)
        {
            return Helpers.ParseElement(obj.Ancestor(tag));
        }

        public virtual DynValue Ancestor(string tag, DynValue findBy, DynValue s1, DynValue s2)
        {
            return Helpers.ParseElement(obj.Ancestor(tag, Helpers.ParseConstraint(findBy, s1, s2)));
        }

        public virtual DynValue Ancestor(DynValue findBy, DynValue s1, DynValue s2)
        {
            return Helpers.ParseElement(obj.Ancestor(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        public virtual void Blur()
        {
            obj.Blur();
        }

        public virtual void Change()
        {
            obj.Change();
        }

        public virtual void Click(bool wait = true)
        {
            if (wait)
                obj.Click();
            else
                obj.ClickNoWait();
        }

        public virtual void DoubleClick()
        {
            obj.DoubleClick();
        }

        public virtual bool Equals(cElement ele)
        {
            return obj.Equals(ele.obj);
        }

        public virtual void FireEvent(string eventName, bool wait = true)
        {
            if (wait)
                obj.FireEvent(eventName);
            else
                obj.FireEventNoWait(eventName);
        }

        public virtual void Flash(int flashes = 0)
        {
            if (flashes > 0)
                obj.Flash(flashes);
            else
                obj.Flash();
        }

        public virtual void Focus()
        {
            obj.Focus();
        }

        public virtual void Highlight(bool doHighlight = true)
        {
            obj.Highlight(doHighlight);
        }

        public virtual void KeyDown(string key = "")
        {
            if (String.IsNullOrWhiteSpace(key))
                obj.KeyDown();
            else
                obj.KeyDown(Convert.ToChar(key));
        }

        public virtual void KeyPress(string key = "")
        {
            if (String.IsNullOrWhiteSpace(key))
                obj.KeyPress();
            else
                obj.KeyPress(Convert.ToChar(key));
        }

        public virtual void KeyUp(string key = "")
        {
            if (String.IsNullOrWhiteSpace(key))
                obj.KeyUp();
            else
                obj.KeyUp(Convert.ToChar(key));
        }

        public virtual void MouseDown()
        {
            obj.MouseDown();
        }

        public virtual void MouseEnter()
        {
            obj.MouseEnter();
        }

        public virtual void MouseUp()
        {
            obj.MouseEnter();
        }

        public virtual void Refresh()
        {
            obj.Refresh();
        }

        public virtual void SetAttribute(string attr, string val)
        {
            obj.SetAttributeValue(attr, val);
        }

        public virtual void WaitForComplete()
        {
            obj.WaitForComplete();
        }

        public virtual void WaitUntil(DynValue findBy, DynValue s1, DynValue s2)
        {
            obj.WaitUntil(Helpers.ParseConstraint(findBy, s1, s2));
        }

        public virtual void WaitUntil(int timeout, DynValue findBy, DynValue s1, DynValue s2)
        {
            if (timeout > 0)
                obj.WaitUntil(Helpers.ParseConstraint(findBy, s1, s2), timeout);
            else
                obj.WaitUntil(Helpers.ParseConstraint(findBy, s1, s2));
        }

        public virtual void WaitUntil(string attr, string value, int timeout = 0)
        {
            if (timeout > 0)
                obj.WaitUntil(attr, value, timeout);
            else
                obj.WaitUntil(attr, value);
        }
        
        public virtual void WaitUntilExists(int timeout = 0)
        {
            if (timeout > 0)
                obj.WaitUntilExists(timeout);
            else
                obj.WaitUntilExists();
        }

        public virtual void WaitUntilRemoved(int timeout = 0)
        {
            if (timeout > 0)
                obj.WaitUntilRemoved(timeout);
            else
                obj.WaitUntilRemoved();
        }

        #endregion
    }

    [MoonSharpUserData]
    public class cElement<T> : cElement
        where T : Element
    {
        private Element<T> obj;

        public cElement(Element<T> baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }
    }
}
