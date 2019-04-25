using System;
using System.Text;

namespace ConsoleUI
{
    internal class ConsoleEx : IConsole
    {
        private Action<string> _writeAction = (string text) => Console.Write(text);
        private Action<string> _writeLineAction = (string text) => Console.WriteLine(text);

        internal ConsoleEx()
        {
            Console.OutputEncoding = Encoding.UTF8;
        }

        public void Write(string text)
        {
            Console.Write(text);
        }
        
        public void Write(string text, ConsoleColor color)
        {
            OutputToConsole(text, color, _writeAction);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void WriteLine(string text, ConsoleColor color)
        {
            OutputToConsole(text, color, _writeLineAction);
        }

        public void ClearConsole()
        {
            Console.Clear();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        private void OutputToConsole(string text, ConsoleColor color, Action<string> action)
        {
            var bufferColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            action.Invoke(text);
            Console.ForegroundColor = bufferColor;
        }
    }
}
