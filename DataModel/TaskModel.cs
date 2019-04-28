﻿using System;
using DataModel.Abstractions;

namespace DataModel
{
    /// <summary>
    /// Represents to-do task entity.
    /// </summary>
    public class TaskModel : ITaskModel
    {
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { _name = $"task {DateTime.Now.Ticks}"; }
                else { _name = value; }
            }
        }
        private string _name;

        public string Description
        {
            get => _description;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { _description = "something to do"; }
                else { _description = value; }
            }
        }
        private string _description;

        public bool Important { get; set; }

        public bool AllDay { get; set; }

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                if (EndDate <= value)
                {
                    TimeSpan diff = value - EndDate;
                    EndDate = value + diff - new TimeSpan(1, 0, 0, 0);
                }
                _startDate = value;
            }
        }
        private DateTime _startDate;

        public DateTime EndDate
        {
            get
            {
                if (AllDay)
                {
                    return new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, 23, 59, 59);
                }
                else { return _endDate; }
            }
            set
            {
                if (StartDate > value) { AllDay = true; }
                _endDate = value;
            }
        }
        private DateTime _endDate;

        /// <summary>
        /// Sets up new all day task.
        /// </summary>
        /// <param name="description">Description string of a task.</param>
        /// <param name="startDate">Start date of a task</param>
        /// <param name="isImportant">Importance flag</param>
        public TaskModel(string name, string description, DateTime startDate, bool isImportant = false)
        {
            InitializeProperties(name, description, startDate, startDate, isImportant);
        }

        /// <summary>
        /// Sets up new task with defined end date.
        /// </summary>
        /// <param name="description">Description string of a task.</param>
        /// <param name="startDate">Start date of a task</param>
        /// <param name="endDate">End date of a task</param>
        /// <param name="isImportant">Importance flag</param>
        public TaskModel(string name, string description, DateTime startDate, DateTime endDate, bool isImportant = false)
        {
            InitializeProperties(name, description, startDate, endDate, isImportant);
        }

        private void InitializeProperties(string name, string description, DateTime startDate, DateTime endDate, bool isImporant = false)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Important = isImporant;
            if (startDate == endDate) { AllDay = true; }
        }
    }
}
