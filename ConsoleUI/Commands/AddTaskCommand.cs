using DataModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    public class AddTaskCommand : UiCommand, IUiCommand
    {
        private readonly ITaskBuilder _taskBuilder;
        private readonly ITaskManager _taskManager;
        public string Name { get; } = "add";
        public string HelpMessage { get; } = "Creates new task";

        public AddTaskCommand(IConsole console, ITaskManager taskManager, ITaskBuilder taskBuilder)
            :base(console)
        {
            _taskBuilder = taskBuilder;
            _taskManager = taskManager;
        }

        public void Invoke()
        {
            _console.WriteLine("Name: ");
            string name = _console.ReadLine();
            _console.WriteLine("Description: ");
            string desc = _console.ReadLine();
            _taskManager.AddTask(_taskBuilder.BuildTask(name, desc, DateTime.Now));
        }
    }
}
