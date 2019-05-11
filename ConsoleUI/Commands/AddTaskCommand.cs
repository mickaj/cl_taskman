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
        public string HelpMessage { get; } = "Creates new task. Input format: [name;description;start date;end date].\n* Important: use semicolon as a separator between values, semicolon is not allowed in name or description.\n* Date/time format: 'dd-MM-yyyy hh:mm'.\n* Ommit end date to create all day task\n* To set a task as important add 'true' as last parameter\n* Example: 'task;task description;12-12-2019;13-12-2019;true'";

        public AddTaskCommand(IConsole console, ITaskManager taskManager, ITaskBuilder taskBuilder)
            : base(console)
        {
            _taskBuilder = taskBuilder;
            _taskManager = taskManager;
        }

        public void Invoke()
        {
            _console.Write("name;description;start date;end date;importance: ", ConsoleColor.Green);
            string input = _console.ReadLine();
            if (ValidateString(input, out string[] separated))
            {
                string name = separated[0];
                string desc = separated[1];
                DateTime startDate = DateTime.Parse(separated[2]);

                DateTime? endDate = null;
                if (separated.Length >= 4)
                {
                    if (!string.IsNullOrWhiteSpace(separated[3])) { endDate = DateTime.Parse(separated[3]); }
                }

                ITaskModel newTask;
                if (endDate.HasValue) { newTask = _taskBuilder.BuildTask(name, desc, startDate, endDate.Value); }
                else { newTask = _taskBuilder.BuildTask(name, desc, startDate); }

                if (separated.Length >= 5)
                {
                    if (separated[4].ToLower() == "true") { newTask.Important = true; }
                }

                _taskManager.AddTask(newTask);
                _console.Write("Task '", ConsoleColor.Green);
                _console.Write(newTask.Name, ConsoleColor.Blue);
                _console.WriteLine("' has been added!", ConsoleColor.Green);
            }
            else { _console.WriteLine("Invalid input string!", ConsoleColor.Red); }
        }

        private bool ValidateString(string input, out string[] output)
        {
            output = input.Split(';');
            if (output.Length >= 3 && output.Length <= 5)
            {
                if (!DateTime.TryParse(output[2], out _)) { return false; }
                if (output.Length >= 4)
                {
                    if (!string.IsNullOrWhiteSpace(output[3]) && !DateTime.TryParse(output[3], out _)) { return false; }
                }
                return true;
            }
            return false;
        }
    }
}
