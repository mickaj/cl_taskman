using DataModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    public class ListTasksCommand : UiCommand, IUiCommand
    {
        public string Name { get => "list"; }
        public string HelpMessage { get => "List all tasks"; }

        private readonly ITaskManager _taskManager;

        public ListTasksCommand(IConsole console, ITaskManager taskManager)
            :base(console)
        {
            _taskManager = taskManager;
        }

        public void Invoke()
        {
            foreach(ITaskModel task in _taskManager.GetTasks())
            {
                _console.WriteLine($"{task.Name} | {task.Description}");
            }
        }
    }
}
