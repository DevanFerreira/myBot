using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;
using myBotStudio.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;
using WatiN.Core.DialogHandlers;
using WatiN.Core.Native.Windows;

namespace myBotStudio.Managers
{
    public enum FindBy
    {
        Attribute,
        AltText,
        Class,
        Default,
        For,
        Id,
        Index,
        Label,
        Name,
        Selector,
        Source,
        Style,
        Text,
        TextInColumn,
        Title,
        Url,
        Value,
        First,
        Near,
        Any,
    }

    public enum DialogHandler
    {
        AlertAndConfirm,
        Alert,
        Certificate,
        CloseIE,
        Confirm,
        FileDownload,
        FileUpload,
        Java,
        Logon,
        Print,
        Prompt,
        RefreshWarning,
        Return,
        SecurityAlert,
        SimpleJava,
        VbScriptMsgBox,
    }

    public class BrowserManager
    {
        public void SetupApi(ref Script script)
        {
            script.Globals["__CreateBrowser"] = (Func<cIE>)(() => { return new cIE(); });

            script.Globals["FIND_BY_ATTRIBUTE"] = FindBy.Attribute;
            script.Globals["FIND_BY_ALT_TEXT"] = FindBy.AltText;
            script.Globals["FIND_BY_CLASS"] = FindBy.Class;
            script.Globals["FIND_BY_DEFAULT"] = FindBy.Default;
            script.Globals["FIND_BY_FOR"] = FindBy.For;
            script.Globals["FIND_BY_ID"] = FindBy.Id;
            script.Globals["FIND_BY_INDEX"] = FindBy.Index;
            script.Globals["FIND_BY_LABEL"] = FindBy.Label;
            script.Globals["FIND_BY_NAME"] = FindBy.Name;
            script.Globals["FIND_BY_SELECTOR"] = FindBy.Selector;
            script.Globals["FIND_BY_SOURCE"] = FindBy.Source;
            script.Globals["FIND_BY_STYLE"] = FindBy.Style;
            script.Globals["FIND_BY_TEXT"] = FindBy.Text;
            script.Globals["FIND_BY_TEXT_IN_COLUMN"] = FindBy.TextInColumn;
            script.Globals["FIND_BY_TITLE"] = FindBy.Title;
            script.Globals["FIND_BY_URL"] = FindBy.Url;
            script.Globals["FIND_BY_VALUE"] = FindBy.Value;
            script.Globals["FIND_BY_FIRST"] = FindBy.First;
            script.Globals["FIND_BY_NEAR"] = FindBy.Near;
            script.Globals["FIND_BY_ANY"] = FindBy.Any;

            script.Globals["WINDOW_STYLE_FORCE_MINIMIZED"] = NativeMethods.WindowShowStyle.ForceMinimized;
            script.Globals["WINDOW_STYLE_HIDE"] = NativeMethods.WindowShowStyle.Hide;
            script.Globals["WINDOW_STYLE_MAXIMIZE"] = NativeMethods.WindowShowStyle.Maximize;
            script.Globals["WINDOW_STYLE_MINIMIZE"] = NativeMethods.WindowShowStyle.Minimize;
            script.Globals["WINDOW_STYLE_RESTORE"] = NativeMethods.WindowShowStyle.Restore;
            script.Globals["WINDOW_STYLE_SHOW"] = NativeMethods.WindowShowStyle.Show;
            script.Globals["WINDOW_STYLE_SHOW_DEFAULT"] = NativeMethods.WindowShowStyle.ShowDefault;
            script.Globals["WINDOW_STYLE_SHOW_MAXIMIZED"] = NativeMethods.WindowShowStyle.ShowMaximized;
            script.Globals["WINDOW_STYLE_SHOW_MINIMIZED"] = NativeMethods.WindowShowStyle.ShowMinimized;
            script.Globals["WINDOW_STYLE_SHOW_MINIMUM_NO_ACTIVE"] = NativeMethods.WindowShowStyle.ShowMinNoActivate;
            script.Globals["WINDOW_STYLE_SHOW_NO_ACTIVE"] = NativeMethods.WindowShowStyle.ShowNoActivate;
            script.Globals["WINDOW_STYLE_SHOW_NORMAL"] = NativeMethods.WindowShowStyle.ShowNormal;
            script.Globals["WINDOW_STYLE_SHOW_NORMAL_NO_ACTIVE"] = NativeMethods.WindowShowStyle.ShowNormalNoActivate;
        }
    }
}
