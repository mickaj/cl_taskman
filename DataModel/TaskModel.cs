using System;

namespace DataModel
{
    /// <summary>
    /// Represents to-do task entity.
    /// </summary>
    public class TaskModel
    {
        private const string EmptyDescriptionExceptionMessage = "Task description cannot be empty!";
        private const string EndDateBeforeStartDateExceptionMessage = "End date cannot be set before start date.";

        /// <summary>
        /// Defines description of a task.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Exception is thrown when attempted to set blank description.
        /// </exception>
        public string Description
        {
            get => _description;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentException(EmptyDescriptionExceptionMessage); }
                else { _description = value; }
            }
        }
        private string _description;

        /// <summary>
        /// Determines whether a task is of high importance.
        /// </summary>
        public bool Important { get; set; } = false;

        /// <summary>
        /// Defines start date of a task.
        /// If a task already has end date set up:
        /// If new start date is before end date it will set start date normally.
        /// if new start date is the same as end date it will set a task as all-day.
        /// If new start date is after current end date it will postpone end date by current time span. 
        /// </summary>
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                if (EndDate.HasValue)
                {
                    if (EndDate == value)
                    {
                        EndDate = null;
                        _startDate = value;
                    }
                    if (EndDate > value)
                    {
                        _startDate = value;
                    }
                    if (EndDate < value)
                    {
                        TimeSpan diff = value - EndDate.Value;
                        EndDate = value + diff - new TimeSpan(1, 0, 0, 0);
                        _startDate = value;
                    }
                }
                else
                {
                    _startDate = value;
                }
            }
        }
        private DateTime _startDate;

        /// <summary>
        /// Defines end date of a task.
        /// if new end date is the same as current start date it will set a task as all-day.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Exception is thrown when attempted to set end date current before start date.
        /// </exception>
        public DateTime? EndDate
        {
            get => _endDate;
            set
            {
                if (value == null)
                {
                    _endDate = value;
                }
                else
                {
                    if (value < StartDate) { throw new ArgumentException(EndDateBeforeStartDateExceptionMessage); }
                    if (value == StartDate) { _endDate = null; }
                    else { _endDate = value; }
                }
            }
        }
        private DateTime? _endDate;

        /// <summary>
        /// Checks if a task is set for all day.
        /// A task is set for all day if EndDate is not set (null).
        /// </summary>
        public bool AllDay
        {
            get => !EndDate.HasValue;
        }

        /// <summary>
        /// Sets up new all day task.
        /// </summary>
        /// <param name="description">Description string of a task.</param>
        /// <param name="startDate">Start date of a task</param>
        /// <param name="isImportant">Importance flag</param>
        public TaskModel(string description, DateTime startDate, bool isImportant = false)
        {
            InitializeProperties(description, startDate, null, isImportant);
        }

        /// <summary>
        /// Sets up new task with defined end date.
        /// </summary>
        /// <param name="description">Description string of a task.</param>
        /// <param name="startDate">Start date of a task</param>
        /// <param name="endDate">End date of a task</param>
        /// <param name="isImportant">Importance flag</param>
        public TaskModel(string description, DateTime startDate, DateTime endDate, bool isImportant = false)
        {
            InitializeProperties(description, startDate, endDate, isImportant);
        }

        private void InitializeProperties(string description, DateTime startDate, DateTime? endDate, bool isImporant = false)
        {
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Important = isImporant;
        }

        /// <summary>
        /// Sets a task as all-day by clearing EndDate value.
        /// </summary>
        public void SetAllDay()
        {
            EndDate = null;
        }
    }
}
