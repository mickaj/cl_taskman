using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    public class DrawHeaderCommand : UiCommand, IUiCommand
    {
        public string Name { get; } = "header";
        public string HelpMessage { get; } = "Re-draws application header";

        public DrawHeaderCommand(IConsole console)
            :base(console)
        {
        }

        public void Invoke()
        {
            _console.WriteLine("**************************", ConsoleColor.Blue);
            _console.Write("**     ", ConsoleColor.Blue);
            _console.Write("TASK MANAGER", ConsoleColor.Red);
            _console.WriteLine("     **", ConsoleColor.Blue);
            _console.Write("**     ", ConsoleColor.Blue);
            _console.Write("Michał Kajzer", ConsoleColor.Green);
            _console.WriteLine("    **", ConsoleColor.Blue);
            _console.WriteLine("**************************", ConsoleColor.Blue);
        }
    }
}
