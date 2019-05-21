using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    public abstract class UiCommandBase
    {
        protected readonly IConsole _console;

        public UiCommandBase(IConsole console)
        {
            _console = console;
        }
    }
}
