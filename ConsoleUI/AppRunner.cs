using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    internal class AppRunner
    {
        private readonly IConsole _console;
        private IDictionary<string, Action> _commands = new Dictionary<string, Action>();

        internal AppRunner(IConsole console)
        {
            _console = console;
            PopulateActionsDictionary();
        }

        internal void Start()
        {
            DrawAppHeader();
            HelpCommand();
            AppLoop();
        }

        internal void AppLoop()
        {
            string command = string.Empty;
            while (command.ToLower() != "exit")
            {
                command = _console.ReadLine();
                if (_commands.ContainsKey(command.ToLower()))
                {
                    _commands[command.ToLower()].Invoke();
                }
                else
                {
                    _console.WriteLine("Unrecognized command", ConsoleColor.Red);
                }
            }
        }

        private void PopulateActionsDictionary()
        {
            _commands.Add("clear", ClearCommand);
            _commands.Add("help", HelpCommand);
            _commands.Add("exit", () => { });
        }

        internal void DrawAppHeader()
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

        internal void HelpCommand()
        {
            _console.WriteLine("Commands:", ConsoleColor.Blue);
            _console.Write("help", ConsoleColor.Green);
            _console.Write(" - display list of commands\n", ConsoleColor.Red);
            _console.Write("clear", ConsoleColor.Green);
            _console.Write(" - clear console\n", ConsoleColor.Red);
            _console.Write("exit", ConsoleColor.Green);
            _console.Write(" - quit application\n", ConsoleColor.Red);
        }

        internal void ClearCommand()
        {
            _console.ClearConsole();
            DrawAppHeader();
        }
    }
}
