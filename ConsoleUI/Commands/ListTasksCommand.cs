using DataModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    public class ListTasksCommand : UiCommand, IUiCommand
    {
        private const string nameHeader = "Task name";
        private const string descriptionHeader = "Description";
        private const string importanceHeader = "Important";
        private const string startDateHeader = "Starts";
        private const string endDateHeader = "Ends";
        private const string allDayHeader = "All day";

        private const string dateFormat = "dd-MM-yyyy hh:mm";

        private const int maxDesc = 30;

        int _nameLength;
        int _descLength;
        int _importanceLength;
        int _dateLength;
        int _allDayLength;

        public string Name { get => "list"; }
        public string HelpMessage { get => "List all tasks"; }

        private readonly ITaskManager _taskManager;

        public ListTasksCommand(IConsole console, ITaskManager taskManager)
            :base(console)
        {
            _taskManager = taskManager;
        }

        public void Invoke()
        {
            PrintTableHeader();
            if(_taskManager.TaskCount > 0) { PrintTasks(); }
            else { _console.WriteLine("list is empty...", ConsoleColor.DarkRed); }
            _console.Write("\n");
        }

        private void PrintTableHeader()
        {
            _nameLength = nameHeader.Length;
            _descLength = descriptionHeader.Length;
            _importanceLength = importanceHeader.Length;
            _dateLength = dateFormat.Length;
            _allDayLength = allDayHeader.Length;

            foreach(ITaskModel task in _taskManager.GetTasks())
            {
                if(task.Name.Length > _nameLength) { _nameLength = task.Name.Length; }
                if(task.Description.Length > _descLength)
                {
                    if(task.Description.Length < maxDesc) { _descLength = task.Description.Length; }
                    else { _descLength = maxDesc; }
                }
            }

            int totalWidth = _nameLength + _descLength + _importanceLength + _dateLength * 2 + _allDayLength;

            _console.WriteLine($"\n| {nameHeader.PadRight(_nameLength + 3)}| {descriptionHeader.PadRight(_descLength + 3)}| {importanceHeader.PadRight(_importanceLength + 3)}| {startDateHeader.PadRight(_dateLength + 1)}| {endDateHeader.PadRight(_dateLength + 1)}| {allDayHeader.PadRight(_allDayLength + 3)}|", ConsoleColor.Blue);
            _console.WriteLine("-".PadRight(totalWidth+27, '-'), ConsoleColor.Blue);
        }

        private void PrintTasks()
        {
            foreach (ITaskModel task in _taskManager.GetTasks())
            {
                _console.WriteLine($"| {task.Name.PadRight(_nameLength + 3)}| {task.Description.Substring(0, task.Description.Length > maxDesc ? maxDesc : task.Description.Length - 1).PadRight(_descLength + 3)}| {task.Important.ToString().PadRight(_importanceLength + 3)}| {task.StartDate.ToString(dateFormat).PadRight(_dateLength + 1)}| {task.EndDate.ToString(dateFormat).PadRight(_dateLength + 1)}| {task.AllDay.ToString().PadRight(_allDayLength + 3)}|", ConsoleColor.Blue);
            }
        }
    }
}
