using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public interface IConsole
    {
        void Write(string text);
        void Write(string text, ConsoleColor color);

        void WriteLine(string text);
        void WriteLine(string text, ConsoleColor color);

        void ClearConsole();

        string ReadLine();
    }
}
