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
    }
}
