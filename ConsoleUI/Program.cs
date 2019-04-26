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
            IConsole console = new ConsoleEx();
            ITaskManager taskManager = new TaskManager();
            ITaskBuilder taskBuilder = new TaskBuilder();
            ICommandsCollection commandsCollection = new CommandsCollection(console, taskManager, taskBuilder);

            AppRunner app = new AppRunner(console, commandsCollection, taskManager);

            app.Start();
        }
    }
}
