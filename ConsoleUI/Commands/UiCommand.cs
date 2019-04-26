using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    public abstract class UiCommand
    {
        protected readonly IConsole _console;

        public UiCommand(IConsole console)
        {
            _console = console;
        }
    }
}
