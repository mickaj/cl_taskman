using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class TaskManager
    {
        private const string TaskAlreadyPresentExceptionMessage = "Task already in collection. Cannot add twice!";
        private const string TaskDoesntBelongToCollectionExceptionMessage = "Cannot removed the task as it doesn't belong to collection.";
        private const string TaskWithGivenIndexDoesNotExistsExceptionMessage = "Task with given index doesn't exist in collection";

        private List<TaskModel> _tasks = new List<TaskModel>();

        public TaskManager()
        {
        }

        public TaskManager(IEnumerable<TaskModel> source)
        {
            _tasks = new List<TaskModel>(source);
        }

        public void AddTask(TaskModel task)
        {
            if (_tasks.Contains(task)) { throw new ArgumentException(TaskAlreadyPresentExceptionMessage); }
            else { _tasks.Add(task); }
        }

        public void RemoveTask(TaskModel task)
        {
            if (_tasks.Contains(task)) { _tasks.Remove(task); }
            else { throw new ArgumentException(TaskDoesntBelongToCollectionExceptionMessage); }
        }

        public IEnumerable<TaskModel> GetTasks()
        {
            return new List<TaskModel>(_tasks) as IEnumerable<TaskModel>;
        }

        public TaskModel GetTask(int index)
        {
            if(_tasks.Count > index) {return _tasks[index];}
            else {throw new ArgumentException(TaskWithGivenIndexDoesNotExistsExceptionMessage);}
        }
    }
}
