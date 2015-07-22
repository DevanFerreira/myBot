using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBotStudio.Managers
{
    [MoonSharpUserData]
    public class ConsoleManager
    {
        [MoonSharpVisible(false)]
        public void SetupApi(ref Script script)
        {
            script.Globals["Console"] = this;

            script.Globals["MSG_COLOR_BLACK"] = ConsoleColor.Black;
            script.Globals["MSG_COLOR_BLUE"] = ConsoleColor.Blue;
            script.Globals["MSG_COLOR_CYAN"] = ConsoleColor.Cyan;
            script.Globals["MSG_COLOR_DARK_BLUE"] = ConsoleColor.DarkBlue;
            script.Globals["MSG_COLOR_DARK_CYAN"] = ConsoleColor.DarkCyan;
            script.Globals["MSG_COLOR_DARK_GRAY"] = ConsoleColor.DarkGray;
            script.Globals["MSG_COLOR_DARK_GREEN"] = ConsoleColor.DarkGreen;
            script.Globals["MSG_COLOR_DARK_MAGENTA"] = ConsoleColor.DarkMagenta;
            script.Globals["MSG_COLOR_DARK_RED"] = ConsoleColor.DarkRed;
            script.Globals["MSG_COLOR_DARK_YELLOW"] = ConsoleColor.DarkYellow;
            script.Globals["MSG_COLOR_GRAY"] = ConsoleColor.Gray;
            script.Globals["MSG_COLOR_GREEN"] = ConsoleColor.Green;
            script.Globals["MSG_COLOR_MAGENTA"] = ConsoleColor.Magenta;
            script.Globals["MSG_COLOR_RED"] = ConsoleColor.Red;
            script.Globals["MSG_COLOR_WHITE"] = ConsoleColor.White;
            script.Globals["MSG_COLOR_YELLOW"] = ConsoleColor.Yellow;

            script.Globals["Write"] = (Action<string, ConsoleColor>)FancyConsole.Write;
            script.Globals["WriteLine"] = (Action<string, ConsoleColor>)FancyConsole.WriteLine;
            script.Globals["WriteSeparator"] = (Action<ConsoleColor>)FancyConsole.WriteSeparator;
        }

        public string Title
        {
            get { return Console.Title; }
            set
            {
                if (String.Equals(value, Title))
                    return;

                Console.Title = value;
            }
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public string ReadKey(bool intercept = false)
        {
            return Console.ReadKey(intercept).KeyChar.ToString();
        }
    }
}
