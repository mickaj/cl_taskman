using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Abstractions
{
    public interface ITaskManager
    {
        int TaskCount { get; }
        void AddTask(ITaskModel task);
        int AddTasks(IEnumerable<ITaskModel> tasks);
        void RemoveTask(ITaskModel task);
        IEnumerable<ITaskModel> GetTasks();
        ITaskModel GetTask(int index);
    }
}
