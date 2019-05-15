using DataModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    public class CommandsCollection : ICommandsCollection
    {
        protected List<IUiCommand> _commands = new List<IUiCommand>();

        public CommandsCollection(IConsole console, ITaskManager taskManager, ITaskBuilder taskBuilder)
        {
            _commands.Add(new DrawHeaderCommand(console));
            _commands.Add(new ClearCommand(console, _commands[0] as DrawHeaderCommand));
            _commands.Add(new HelpCommand(console, this));
            _commands.Add(new AddTaskCommand(console, taskManager, taskBuilder));
            _commands.Add(new ListTasksCommand(console, taskManager));
            _commands.Add(new ShowTaskCommand(console, taskManager));
            _commands.Add(new EditTaskCommand(console, taskManager, taskBuilder));
        }

        public IReadOnlyList<IUiCommand> Commands { get => _commands.AsReadOnly(); }
    }
}
