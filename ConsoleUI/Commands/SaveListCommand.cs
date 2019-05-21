using DataModel.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleUI.Commands
{
    public class SaveListCommand : UiCommandBase, IUiCommand
    {
        private readonly ITaskManager _taskManager;
        private readonly IConverter _converter;

        public string Name { get; } = "save";
        public string HelpMessage { get; } = "Saves list of tasks to *.csv file.";

        public SaveListCommand(IConsole console, ITaskManager taskManager, IConverter converter)
            :base(console)
        {
            _taskManager = taskManager;
            _converter = converter;
        }

        public void Invoke()
        {
            _console.Write("Save to file path: ", ConsoleColor.Green);
            string path = _console.ReadLine();
            try
            {
                File.WriteAllLines(path, _converter.ToStringArray(_taskManager.GetTasks()));
            }
            catch(Exception e)
            {
                _console.WriteLine($"Saving failed. Reason: {e.Message}");
            }
            _console.Write("File '", ConsoleColor.Green);
            _console.Write(path, ConsoleColor.Blue);
            _console.WriteLine("' has been sucesfully saved!", ConsoleColor.Green);
        }
    }
}
