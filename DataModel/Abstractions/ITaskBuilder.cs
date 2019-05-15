using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Abstractions
{
    public interface ITaskBuilder
    {
        ITaskModel BuildTask(string name, string description, DateTime startDate, bool isImportant = false);
        ITaskModel BuildTask(string name, string description, DateTime startDate, DateTime endDate, bool isImportant = false);

        ITaskModel Parse(string input);

        bool ReParse(string input, ITaskModel task);
    }
}
