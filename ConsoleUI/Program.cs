using ConsoleUI.Commands;
using DataModel;
using DataModel.Abstractions;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsole console = new ConsoleEx("cl-mickaj console task manager");
            ITaskManager taskManager = new TaskManager();
            ITaskBuilder taskBuilder = new TaskBuilder();
            IConverter converter = new CsvConverter(taskBuilder);
            ICommandsCollection commandsCollection = new CommandsCollection(console, taskManager, taskBuilder, converter);

            AppRunner app = new AppRunner(console, commandsCollection, taskManager);

            app.Start();
        }
    }
}
