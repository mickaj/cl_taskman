using DataModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    public class ShowTaskCommand : UiCommand, IUiCommand
    {
        private readonly ITaskManager _taskManager;

        public string Name { get; } = "show";
        public string HelpMessage { get; } = "Display all properties of a task sepcified by its index.\n* Usage: type command and hit press enter, you will be prompted for task's index.";

        public ShowTaskCommand(IConsole console, ITaskManager taskManager)
            :base(console)
        {
            _taskManager = taskManager;
        }

        public void Invoke()
        {
            _console.WriteLine("task details");
        }
    }
}
