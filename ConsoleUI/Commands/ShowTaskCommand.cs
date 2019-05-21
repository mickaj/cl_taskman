using DataModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    public class ShowTaskCommand : UiCommandBase, IUiCommand
    {
        private readonly ITaskManager _taskManager;

        public string Name { get; } = "show";
        public string HelpMessage { get; } = "Display all properties of a task sepcified by its index.\n* Usage: type command and press enter, you will be prompted for task's index.";

        public ShowTaskCommand(IConsole console, ITaskManager taskManager)
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
                    _console.WriteLine($"\n*****TASK #{id}*****", ConsoleColor.Blue);
                    _console.Write("Name: ", ConsoleColor.Blue);
                    _console.WriteLine(task.Name);
                    _console.Write("Description: ", ConsoleColor.Blue);
                    _console.WriteLine(task.Description);
                    _console.Write("Important: ", ConsoleColor.Blue);
                    _console.WriteLine(task.Important.ToString(), task.Important ? ConsoleColor.Red : ConsoleColor.White);
                    _console.Write("Start date: ", ConsoleColor.Blue);
                    _console.WriteLine(task.StartDate.ToString(_dateFormat));
                    _console.Write("End date: ", ConsoleColor.Blue);
                    _console.WriteLine(task.EndDate.ToString(_dateFormat));
                    _console.Write("All day: ", ConsoleColor.Blue);
                    _console.WriteLine(task.AllDay.ToString() + "\n");
                }
                catch
                {
                    _console.WriteLine("task with given id does not exist!", ConsoleColor.Red);
                }
            }
            else { _console.WriteLine("index must be a number!", ConsoleColor.Red); }
        }
    }
}
