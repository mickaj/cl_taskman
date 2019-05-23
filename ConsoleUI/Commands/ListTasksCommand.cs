using DataModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    public class ListTasksCommand : UiCommandBase, IUiCommand
    {
        public string Name { get => "list"; }
        public string HelpMessage { get => "List all tasks"; }

        private readonly ITaskManager _taskManager;

        public ListTasksCommand(IConsole console, ITaskManager taskManager)
            : base(console)
        {
            _taskManager = taskManager;
        }

        public void Invoke()
        {
            if (_taskManager.TaskCount == 0) { _console.WriteLine("list is empty...", ConsoleColor.DarkRed); }
            else
            {
                ListTable lt = new ListTable(_dateFormat);
                foreach (string s in lt.GetStrings(_taskManager.GetTasks()))
                {
                    _console.WriteLine(s, ConsoleColor.Blue);
                }
            }
        }
    }
}
