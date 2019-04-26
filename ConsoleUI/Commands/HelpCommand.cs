using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    public class HelpCommand : UiCommand, IUiCommand
    {
        private ICommandsCollection _commands;
        public string Name { get; } = "help";
        public string HelpMessage { get; } = "Displays all available commands";

        public HelpCommand(IConsole console, ICommandsCollection commands)
            :base(console)
        {
            _commands = commands;
        }

        public void Invoke()
        {
            _console.WriteLine("Commands:", ConsoleColor.Blue);
            foreach(IUiCommand command in _commands.Commands)
            {
                _console.Write(command.Name, ConsoleColor.Green);
                _console.Write(string.Format(" - {0}\n", command.HelpMessage), ConsoleColor.Red);
            }
        }
    }
}
