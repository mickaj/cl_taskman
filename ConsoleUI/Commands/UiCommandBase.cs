using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    public abstract class UiCommandBase
    {
        protected readonly IConsole _console;
        protected const string _dateFormat = "dd-MM-yyyy HH:mm";

        public UiCommandBase(IConsole console)
        {
            _console = console;
        }
    }
}
