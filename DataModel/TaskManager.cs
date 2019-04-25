using System;
using System.Collections.Generic;
using System.Text;
using DataModel.Abstractions;

namespace DataModel
{
    public class TaskManager : ITaskManager
    {
        private const string TaskAlreadyPresentExceptionMessage = "Task already in collection. Cannot add twice!";
        private const string TaskDoesntBelongToCollectionExceptionMessage = "Cannot removed the task as it doesn't belong to collection.";
        private const string TaskWithGivenIndexDoesNotExistsExceptionMessage = "Task with given index doesn't exist in collection";

        private List<ITaskModel> _tasks = new List<ITaskModel>();

        public TaskManager()
        {
        }

        public TaskManager(IEnumerable<ITaskModel> source)
        {
            _tasks = new List<ITaskModel>(source);
        }

        public void AddTask(ITaskModel task)
        {
            if (_tasks.Contains(task)) { throw new ArgumentException(TaskAlreadyPresentExceptionMessage); }
            else { _tasks.Add(task); }
        }

        public void RemoveTask(ITaskModel task)
        {
            if (_tasks.Contains(task)) { _tasks.Remove(task); }
            else { throw new ArgumentException(TaskDoesntBelongToCollectionExceptionMessage); }
        }

        public IEnumerable<ITaskModel> GetTasks()
        {
            return new List<ITaskModel>(_tasks) as IEnumerable<ITaskModel>;
        }

        public ITaskModel GetTask(int index)
        {
            if(_tasks.Count > index) {return _tasks[index];}
            else {throw new ArgumentException(TaskWithGivenIndexDoesNotExistsExceptionMessage);}
        }
    }
}
