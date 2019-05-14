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

            ITaskModel task = _taskBuilder.Parse(input);

            if (task != null)
            {
                _taskManager.AddTask(task);
                _console.Write("Task '", ConsoleColor.Green);
                _console.Write(task.Name, ConsoleColor.Blue);
                _console.WriteLine("' has been added!", ConsoleColor.Green);
            }
            else { _console.WriteLine("Invalid input string!", ConsoleColor.Red); }
        }
    }
}
