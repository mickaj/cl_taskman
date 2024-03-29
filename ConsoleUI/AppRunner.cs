﻿using ConsoleUI.Commands;
using DataModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleUI
{
    internal class AppRunner
    {
        private readonly IConsole _console;
        private readonly ICommandsCollection _commands;

        internal AppRunner(IConsole console, ICommandsCollection commands)
        {
            _console = console;
            _commands = commands;
        }

        internal void Start()
        {
            if (_commands.Commands.Any(command => command.Name == "header")) { _commands.Commands.First(command => command.Name == "header").Invoke(); }
            if (_commands.Commands.Any(command => command.Name == "help")) { _commands.Commands.First(command => command.Name == "help").Invoke(); }
            AppLoop();
        }

        internal void AppLoop()
        {
            string commandString = string.Empty;
            while (commandString.ToLower() != "exit")
            {
                _console.Write("command: ", ConsoleColor.Green);
                commandString = _console.ReadLine().ToLower();
                if (_commands.Commands.Any(command => command.Name == commandString)) { _commands.Commands.First(command => command.Name == commandString).Invoke(); }
                else { _console.WriteLine("Unrecognized command", ConsoleColor.Red); }
            }
        }
    }
}
