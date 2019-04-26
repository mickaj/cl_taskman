using ConsoleUI.Commands;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsole console = new ConsoleEx();
            ICommandsCollection commandsCollection = new CommandsCollection(console);
            AppRunner app = new AppRunner(console, commandsCollection);

            app.Start();
        }
    }
}
