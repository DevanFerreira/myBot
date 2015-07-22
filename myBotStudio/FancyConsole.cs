using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBotStudio
{
    public static class FancyConsole
    {
        public static void Write(string text = "", ConsoleColor color = ConsoleColor.Cyan)
        {
            if (String.IsNullOrWhiteSpace(text))
                return;

            SetColor(color);
            Console.Write(text);
            SetColor();
        }

        public static void WriteLine(string text = "", ConsoleColor color = ConsoleColor.Cyan)
        {
            if (String.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine();
                return;
            }

            SetColor(color);
            Console.WriteLine(text);
            SetColor();
        }

        public static void SetColor(ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
        }

        public static void WriteSeparator(ConsoleColor color = ConsoleColor.Cyan)
        {
            WriteLine("|----------------------------------------------------------------------------|", color);
        }

        public static string GetInput(string message = "", ConsoleColor color = ConsoleColor.Green)
        {
            if (!String.IsNullOrWhiteSpace(message))
                Write(message, color);

            return Console.ReadLine();
        }
    }
}
