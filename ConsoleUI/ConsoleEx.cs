using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    internal static class ConsoleEx
    {
        private static Action<string> _writeAction = (string text) => Console.Write(text);
        private static Action<string> _writeLineAction = (string text) => Console.WriteLine(text);

        internal static void Initialize()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        internal static void Write(string text, ConsoleColor color)
        {
            OutputToConsole(text, color, _writeAction);
        }

        internal static void WriteLine(string text, ConsoleColor color)
        {
            OutputToConsole(text, color, _writeLineAction);
        }

        internal static void DrawAppHeader()
        {
            WriteLine("**************************", ConsoleColor.Blue);
            Write("**     ", ConsoleColor.Blue);
            Write("TASK MANAGER", ConsoleColor.Red);
            WriteLine("     **", ConsoleColor.Blue);
            Write("**     ", ConsoleColor.Blue);
            Write("Michał Kajzer", ConsoleColor.Green);
            WriteLine("    **", ConsoleColor.Blue);
            WriteLine("**************************", ConsoleColor.Blue);
        }

        internal static void PrintHelp()
        {
            WriteLine("Commands:", ConsoleColor.Blue);
            Write("help", ConsoleColor.Green);
            Write(" - display list of commands\n", ConsoleColor.Red);
            Write("clear", ConsoleColor.Green);
            Write(" - clear console\n", ConsoleColor.Red);
            Write("exit", ConsoleColor.Green);
            Write(" - quit application\n", ConsoleColor.Red);
        }

        internal static void ClearConsole()
        {
            Console.Clear();
            DrawAppHeader();
            PrintHelp();
        }

        private static void OutputToConsole(string text, ConsoleColor color, Action<string> action)
        {
            var bufferColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            action.Invoke(text);
            Console.ForegroundColor = bufferColor;
        }
    }
}
