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
        public string HelpMessage { get; } = "Creates new task. Input format: [name;description;start date;end date].\n* Important: use semicolon as a separator between values, semicolon is not allowed in name or description.\n* Date/time format: 'dd-MM-yyyy hh:mm'.\n* Ommit end date to create all day task ";

        public AddTaskCommand(IConsole console, ITaskManager taskManager, ITaskBuilder taskBuilder)
            :base(console)
        {
            _taskBuilder = taskBuilder;
            _taskManager = taskManager;
        }

        public void Invoke()
        {
            _console.Write("name;description;start date;end date: ", ConsoleColor.Green);
            string input = _console.ReadLine();
            if(ValidateString(input))
            {
                string[] separated = input.Split(';');
                string name = separated[0];
                string desc = separated[1];
                DateTime startDate = DateTime.Parse(separated[2]);
                if (separated.Length == 3)
                {                   
                    var newTask = _taskBuilder.BuildTask(name, desc, startDate);
                    _taskManager.AddTask(newTask);
                }
                if(separated.Length == 4)
                {
                    DateTime endDate = DateTime.Parse(separated[3]);
                    var newTask = _taskBuilder.BuildTask(name, desc, startDate, endDate);
                    _taskManager.AddTask(newTask);
                }
                _console.Write("Task '", ConsoleColor.Green);
                _console.Write(name, ConsoleColor.Blue);
                _console.WriteLine("' has been added!", ConsoleColor.Green);
            }
            else { _console.WriteLine("Invalid input string!", ConsoleColor.Red); }
        }

        private bool ValidateString(string input)
        {
            string[] separated = input.Split(';');
            if(separated.Length>=3 && separated.Length<=4)
            {
                if(!DateTime.TryParse(separated[2], out _)) { return false; }
                if(separated.Length == 4)
                {
                    if(!DateTime.TryParse(separated[3], out _)) { return false; }
                }
                return true;
            }
            return false;
        }
    }
}
