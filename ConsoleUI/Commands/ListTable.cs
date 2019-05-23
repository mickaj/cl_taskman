using DataModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    internal class ListTable
    {
        private const string idHeader = "#";
        private const string nameHeader = "Task name";
        private const string descriptionHeader = "Description";
        private const string importanceHeader = "Important";
        private const string startDateHeader = "Starts";
        private const string endDateHeader = "Ends";
        private const string allDayHeader = "All day";

        private const int maxLength = 30;

        private readonly string _dateFormat;

        private int _idLength;
        private int _nameLength;
        private int _descLength;
        private int _importanceLength;
        private int _dateLength;
        private int _allDayLength;

        private int _totalLength;

        public ListTable(string dateFormat)
        {
            _dateFormat = dateFormat;
            SetDefaultLengths();
        }

        public string[] GetStrings(IEnumerable<ITaskModel> tasks)
        {
            List<string> result = new List<string>();
            List<ITaskModel> taskList = new List<ITaskModel>(tasks);

            CalculateLengths(taskList);
            result.Add(GetHeaderString());
            result.Add("".PadRight(_totalLength, '-'));

            int id = 0;
            foreach (ITaskModel task in tasks)
            {
                result.Add(GetTaskString(task, id++));
            }

            return result.ToArray();
        }

        private void CalculateLengths(IList<ITaskModel> tasks)
        {
            SetDefaultLengths();
            _idLength = tasks.Count.ToString().Length;

            foreach (ITaskModel task in tasks)
            {
                if (task.Name.Length > _nameLength)
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

            _totalLength = _idLength + 3 + _nameLength + 3 + _descLength + 3 + _importanceLength + 3 + 2 * (_dateLength + 3) + _allDayLength + 4 + 1;

        }

        private string GetHeaderString()
        {
            return $"| {idHeader.PadRight(_idLength)} | {nameHeader.PadRight(_nameLength)} | {descriptionHeader.PadRight(_descLength)} | {importanceHeader.PadRight(_importanceLength)} | {startDateHeader.PadRight(_dateLength)} | {endDateHeader.PadRight(_dateLength)} | {allDayHeader.PadRight(_allDayLength)} |";
        }

        private string GetTaskString(ITaskModel task, int taskId)
        {
            string id = taskId.ToString().PadRight(_idLength);
            string name = task.Name.Substring(0, task.Name.Length > maxLength ? maxLength : task.Name.Length).PadRight(_nameLength);
            string desc = task.Description.Substring(0, task.Description.Length > maxLength ? maxLength : task.Description.Length).PadRight(_descLength);
            string important = task.Important.ToString().PadRight(_importanceLength);
            string startDate = task.StartDate.ToString(_dateFormat);
            string endDate = task.AllDay ? " -".PadRight(_dateLength) : task.EndDate.ToString(_dateFormat);
            string allDay = task.AllDay ? " v".PadRight(_allDayLength) : "".PadRight(_allDayLength);

            return $"| {id} | {name} | {desc} | {important} | {startDate} | {endDate} | {allDay} |";
        }

        private void SetDefaultLengths()
        {
            _idLength = idHeader.Length;
            _nameLength = nameHeader.Length;
            _descLength = descriptionHeader.Length;
            _importanceLength = importanceHeader.Length;
            _dateLength = _dateFormat.Length;
            _allDayLength = startDateHeader.Length;
        }
    }
}
