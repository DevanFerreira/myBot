using MoonSharp.Interpreter;
using myBot.Controls;
using myBot.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WatiN.Core;
using WatiN.Core.Constraints;

namespace myBot
{
    public static class Helpers
    {
        public static bool IsValidScriptPath(string path)
        {
            return (!String.IsNullOrWhiteSpace(path) && File.Exists(path) && String.Equals(Path.GetExtension(path), ".lua"));
        }

        public static void Run(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                if (ex is InterpreterException)
                {
                    InterpreterException exc = (ex as InterpreterException);
                    FancyConsole.WriteLine(String.Format("{0} => {1}", exc.DecoratedMessage, exc.CallStack[0].Name), ConsoleColor.Red);
                }
                else if (ex is ScriptRuntimeException)
                {
                    ScriptRuntimeException exc = (ex as ScriptRuntimeException);
                    FancyConsole.WriteLine(String.Format("{0} => {1}", exc.DecoratedMessage, exc.CallStack[0].Name), ConsoleColor.Red);
                }
                else if (ex is StopScriptException)
                    FancyConsole.WriteLine("Execution was stopped through the script!", ConsoleColor.Gray);
                else
                    FancyConsole.WriteLine(ex.Message, ConsoleColor.Red);
            }
        }

        public static Constraint ParseConstraint(DynValue findBy, DynValue _s1, DynValue _s2)
        {
            string s1 = _s1.String;
            string s2 = (_s2.IsNotNil()) ? _s2.String : "";

            switch (findBy.ToObject<FindBy>())
            {
                case FindBy.AltText:
                        return Find.ByAlt(s1);

                case FindBy.Any:
                    return Find.Any;

                case FindBy.Attribute:
                    return Find.By(s1, s2);

                case FindBy.Class:
                    return Find.ByClass(s1, false);

                case FindBy.Default:
                    return Find.ByDefault(s1);

                case FindBy.First:
                    return Find.First();

                case FindBy.For:
                    return Find.ByFor(s1);

                case FindBy.Id:
                    return Find.ById(s1);

                case FindBy.Index:
                    return Find.ByIndex(Convert.ToInt32(s1));

                case FindBy.Label:
                    return Find.ByLabelText(s1);

                case FindBy.Name:
                    return Find.ByName(s1);

                case FindBy.Near:
                    return Find.Near(s1);

                case FindBy.Selector:
                    return Find.BySelector(s1);

                case FindBy.Source:
                    return Find.BySrc(s1);

                case FindBy.Style:
                    return Find.ByStyle(s1, s2);

                case FindBy.Text:
                    return Find.ByText(s1);

                case FindBy.TextInColumn:
                    return Find.ByTextInColumn(s1, Convert.ToInt32(s2));

                case FindBy.Title:
                    return Find.ByTitle(s1);

                case FindBy.Url:
                    return Find.ByUrl(s1);

                case FindBy.Value:
                    return Find.ByValue(s1);
            }

            return Find.None;
        }

        public static DynValue ParseElement(Element ele)
        {
            Type type = null;

            switch (ele.TagName.ToLower())
            {
                case "area":
                    type = typeof(cArea);
                    break;

                case "button":
                    type = typeof(cButton);
                    break;

                case "input":
                    switch (ele.GetAttributeValue("type").ToLower())
                    {
                        case "reset":
                        case "submit":
                        case "button":
                            type = typeof(cButton);
                            break;

                        case "checkbox":
                            type = typeof(cCheckBox);
                            break;

                        case "file":
                            type = typeof(cFileUpload);
                            break;

                        case "image":
                            type = typeof(cImage);
                            break;

                        case "radio":
                            type = typeof(cRadioButton);
                            break;

                        case "textarea":
                        case "text":
                        case "password":
                        case "hidden":
                            type = typeof(cTextField);
                            break;
                    }
                    break;

                case "div":
                    type = typeof(cDiv);
                    break;

                case "form":
                    type = typeof(cForm);
                    break;

                case "frame":
                case "iframe":
                    type = typeof(cFrame);
                    break;

                case "img":
                    type = typeof(cImage);
                    break;

                case "label":
                    type = typeof(cLabel);
                    break;

                case "a":
                    type = typeof(cLink);
                    break;

                case "ul":
                case "ol":
                    type = typeof(cList);
                    break;

                case "li":
                    type = typeof(cListItem);
                    break;

                case "option":
                    type = typeof(cOption);
                    break;

                case "p":
                    type = typeof(cPara);
                    break;

                case "select":
                    type = typeof(cSelectList);
                    break;

                case "span":
                    type = typeof(cSpan);
                    break;

                case "table":
                    type = typeof(cTable);
                    break;

                case "tbody":
                    type = typeof(cTableBody);
                    break;

                case "td":
                    type = typeof(cTableCell);
                    break;

                case "tr":
                    type = typeof(cTableRow);
                    break;

                case "textarea":
                    type = typeof(cTextField);
                    break;
            }

            if (type == null)
                type = typeof(cElement);

            return UserData.Create(Activator.CreateInstance(type, ele));
        }
    }
}
