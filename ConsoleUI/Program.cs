using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleEx.Initialize();

            ConsoleEx.DrawAppHeader();
            ConsoleEx.PrintHelp();

            string command = string.Empty;
            while (command.ToLower() != "exit")
            {
                command = Console.ReadLine();
                switch (command.ToLower())
                {
                    case "clear":
                        ConsoleEx.ClearConsole();
                        break;
                    case "help":
                        ConsoleEx.PrintHelp();
                        break;
                    default:
                        ConsoleEx.WriteLine("Unrecognized command", ConsoleColor.Red);
                        break;
                }
            }
        }
    }
}
