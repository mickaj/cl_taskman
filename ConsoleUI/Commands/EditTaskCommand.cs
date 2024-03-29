﻿using DataModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    public class EditTaskCommand : UiCommandBase, IUiCommand
    {
        private readonly ITaskManager _taskManager;
        private readonly ITaskBuilder _taskBuilder;

        public string Name { get; } = "edit";
        public string HelpMessage { get; } = "Allows to edit a task";

        public EditTaskCommand(IConsole console, ITaskManager taskManager, ITaskBuilder taskBuilder)
            :base(console)
        {
            _taskManager = taskManager;
            _taskBuilder = taskBuilder;
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
                    _console.WriteLine($"{task.Name};{task.Description};{task.StartDate.ToString(_dateFormat)};{task.EndDate.ToString(_dateFormat)};{task.Important.ToString().ToLower()}", ConsoleColor.Blue);
                    _console.Write("name;description;start date;end date;importance: ", ConsoleColor.Green);
                    string readString = _console.ReadLine();
                    if(_taskBuilder.ReParse(readString, task))
                    {
                        _console.Write("Task ", ConsoleColor.Green);
                        _console.Write(task.Name, ConsoleColor.Blue);
                        _console.WriteLine("' has been updated", ConsoleColor.Green);
                    }
                    else { _console.WriteLine("Incorrect update string format. Update failed.", ConsoleColor.Red); }
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
