using DataModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class TaskBuilder : ITaskBuilder
    {
        public ITaskModel BuildTask(string name, string description, DateTime startDate, bool isImportant = false)
        {
            return new TaskModel(name, description, startDate, isImportant);
        }
        public ITaskModel BuildTask(string name, string description, DateTime startDate, DateTime endDate, bool isImportant = false)
        {
            return new TaskModel(name, description, startDate, endDate, isImportant);
        }

        public ITaskModel Parse(string input)
        {
            if (ValidateString(input, out string[] separated))
            {
                string name = separated[0];
                string desc = separated[1];
                DateTime startDate = DateTime.Parse(separated[2]);

                DateTime? endDate = null;
                if (separated.Length >= 4)
                {
                    if (!string.IsNullOrWhiteSpace(separated[3])) { endDate = DateTime.Parse(separated[3]); }
                }

                ITaskModel newTask;
                if (endDate.HasValue) { newTask = BuildTask(name, desc, startDate, endDate.Value); }
                else { newTask = BuildTask(name, desc, startDate); }

                if (separated.Length >= 5)
                {
                    if (separated[4].ToLower() == "true") { newTask.Important = true; }
                }
                return newTask;
            }
            return null;
        }

        private bool ValidateString(string input, out string[] output)
        {
            output = input.Split(';');
            if (output.Length >= 3 && output.Length <= 5)
            {
                if (!DateTime.TryParse(output[2], out _)) { return false; }
                if (output.Length >= 4)
                {
                    if (!string.IsNullOrWhiteSpace(output[3]) && !DateTime.TryParse(output[3], out _)) { return false; }
                }
                return true;
            }
            return false;
        }
    }
}

