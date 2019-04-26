using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    public interface ICommandsCollection
    {
        IReadOnlyList<IUiCommand> Commands { get; }
    }
}
