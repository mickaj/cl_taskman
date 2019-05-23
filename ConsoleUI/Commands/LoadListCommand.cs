using DataModel.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleUI.Commands
{
    public class LoadListCommand : UiCommandBase, IUiCommand
    {
        private readonly ITaskManager _taskManager;
        private readonly IConverter _converter;

        public string Name { get; } = "load";
        public string HelpMessage { get; } = "Loads list of tasks from expported *.csv file.";

        public LoadListCommand(IConsole console, ITaskManager taskManager, IConverter converter)
            : base(console)
        {
            _taskManager = taskManager;
            _converter = converter;
        }

        public void Invoke()
        {
            _console.Write("Load to file path: ", ConsoleColor.Green);
            string path = _console.ReadLine();
            int count = 0;
            try
            {
                string[] import = File.ReadAllLines(path);
                count =_taskManager.AddTasks(_converter.FromStringArray(import));
            }
            catch (Exception e)
            {
                _console.WriteLine($"Loading failed. Reason: {e.Message}",ConsoleColor.Red);
                return;
            }
            _console.Write("File '", ConsoleColor.Green);
            _console.Write(path, ConsoleColor.Blue);
            _console.WriteLine($"' has been sucesfully loaded! Number of added tasks: {count}", ConsoleColor.Green);
        }
    }
}
