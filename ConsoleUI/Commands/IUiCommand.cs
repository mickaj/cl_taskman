using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    public interface IUiCommand
    {
        string Name { get; }
        string HelpMessage { get; }

        void Invoke();
    }
}
