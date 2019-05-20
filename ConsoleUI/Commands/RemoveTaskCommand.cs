using DataModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    public class RemoveTaskCommand : UiCommand, IUiCommand
    {
        private readonly ITaskManager _taskManager;

        public string Name { get; } = "remove";
        public string HelpMessage { get; } = "Removes a task by given index.";

        public RemoveTaskCommand(IConsole console, ITaskManager taskManager)
            : base(console)
        {
            _taskManager = taskManager;
        }

        public void Invoke()
        {
            _console.Write("id: ", ConsoleColor.Green);
            string idString = _console.ReadLine();

            if (int.TryParse(idString, out int id))
            {
                try
                {
                    var task = _taskManager.GetTask(id);
                    _taskManager.RemoveTask(task);
                    _console.Write("Task '", ConsoleColor.Green);
                    _console.Write(task.Name, ConsoleColor.Blue);
                    _console.WriteLine("' has been removed", ConsoleColor.Green);
                }
                catch
                {
                    _console.WriteLine("Task with given id does not exist!", ConsoleColor.Red);
                }
            }
            else { _console.WriteLine("Index must be a number!", ConsoleColor.Red); }
        }
    }
}
