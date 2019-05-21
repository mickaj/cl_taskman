using DataModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    public class ListTasksCommand : UiCommandBase, IUiCommand
    {
        private const string nameHeader = "Task name";
        private const string descriptionHeader = "Description";
        private const string importanceHeader = "Important";
        private const string startDateHeader = "Starts";
        private const string endDateHeader = "Ends";
        private const string allDayHeader = "All day";

        private const int maxLength = 30;

        int _nameLength;
        int _descLength;
        int _importanceLength;
        int _dateLength;
        int _allDayLength;

        public string Name { get => "list"; }
        public string HelpMessage { get => "List all tasks"; }

        private readonly ITaskManager _taskManager;

        public ListTasksCommand(IConsole console, ITaskManager taskManager)
            : base(console)
        {
            _taskManager = taskManager;
        }

        public void Invoke()
        {
            PrintTableHeader();
            if (_taskManager.TaskCount > 0) { PrintTasks(); }
            else { _console.WriteLine("list is empty...", ConsoleColor.DarkRed); }
            _console.Write("\n");
        }

        private void PrintTableHeader()
        {
            _nameLength = nameHeader.Length;
            _descLength = descriptionHeader.Length;
            _importanceLength = importanceHeader.Length;
            _dateLength = _dateFormat.Length;
            _allDayLength = allDayHeader.Length;

            foreach (ITaskModel task in _taskManager.GetTasks())
            {
                if (task.Name.Length > _descLength)
                {
                    if (task.Name.Length < maxLength) { _nameLength = task.Name.Length; }
                    else { _nameLength = maxLength; }
                }

                if (task.Description.Length > _descLength)
                {
                    if (task.Description.Length < maxLength) { _descLength = task.Description.Length; }
                    else { _descLength = maxLength; }
                }
            }

            int totalWidth = _nameLength + _descLength + _importanceLength + _dateLength * 2 + _allDayLength;

            string indexHeader = " #".PadRight(_taskManager.TaskCount.ToString().Length);
            
            _console.WriteLine($"\n| {indexHeader} | {nameHeader.PadRight(_nameLength + 3)}| {descriptionHeader.PadRight(_descLength + 3)}| {importanceHeader.PadRight(_importanceLength + 3)}| {startDateHeader.PadRight(_dateLength + 1)}| {endDateHeader.PadRight(_dateLength + 1)}| {allDayHeader.PadRight(_allDayLength + 3)}|", ConsoleColor.Blue);
            _console.WriteLine("-".PadRight(totalWidth + 31, '-'), ConsoleColor.Blue);
        }

        private void PrintTasks()
        {
            int i = 0;
            var tasks = _taskManager.GetTasks();
            int idColumnPadding = _taskManager.TaskCount.ToString().Length;

            foreach (ITaskModel task in tasks)
            {
                string name = task.Name.Substring(0, task.Name.Length > maxLength ? maxLength : task.Name.Length).PadRight(_nameLength + 3);
                string desc = task.Description.Substring(0, task.Description.Length > maxLength ? maxLength : task.Description.Length).PadRight(_descLength + 3);
                string important = task.Important.ToString().PadRight(_importanceLength + 3);
                string startDate = task.StartDate.ToString(_dateFormat).PadRight(_dateLength + 1);
                string endDate = task.AllDay ? "- ".PadRight(_dateLength + 1) : task.EndDate.ToString(_dateFormat).PadRight(_dateLength + 1);
                string allDay = task.AllDay ? "v ".PadRight(_allDayLength + 3) : "".PadRight(_allDayLength + 3);

                _console.WriteLine($"| {i++.ToString().PadRight(idColumnPadding)} | {name}| {desc}| {important}| {startDate}| {endDate}| {allDay}|", ConsoleColor.Blue);
            }
        }
    }
}
