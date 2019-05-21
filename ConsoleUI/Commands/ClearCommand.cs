using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    public class ClearCommand : UiCommandBase, IUiCommand
    {
        private readonly DrawHeaderCommand _drawHeaderCommand;
        public string Name { get; } = "clear";
        public string HelpMessage { get; } = "Clears console and re-draws header";

        public ClearCommand(IConsole console, DrawHeaderCommand drawHeaderCommand)
            :base(console)
        {
            _drawHeaderCommand = drawHeaderCommand;
        }

        public void Invoke()
        {
            _console.ClearConsole();
            _drawHeaderCommand.Invoke();
        }
    }
}
