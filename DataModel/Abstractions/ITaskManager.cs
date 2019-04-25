using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Abstractions
{
    public interface ITaskManager
    {
        void AddTask(ITaskModel task);
        void RemoveTask(ITaskModel task);
        IEnumerable<ITaskModel> GetTasks();
        ITaskModel GetTask(int index);
    }
}
