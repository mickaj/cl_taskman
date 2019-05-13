using DataModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    public class EditTaskCommand : UiCommand, IUiCommand
    {
        private readonly ITaskManager _taskManager;

        private const string dateFormat = "dd-MM-yyyy HH:mm";

        public string Name { get; } = "edit";
        public string HelpMessage { get; } = "Allows to edit a task";

        public EditTaskCommand(IConsole console, ITaskManager taskManager)
            :base(console)
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
                    _console.Write("name;description;start date;end date;importance: ", ConsoleColor.Green);
                    _console.Write($"{task.Name};{task.Description};{task.StartDate.ToString(dateFormat)};{task.EndDate.ToString(dateFormat)};{task.Important.ToString().ToLower()}");
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
