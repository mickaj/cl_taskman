using System;
using Xunit;

namespace DataModel.Tests
{
    public class TaskModelTests
    {
        private const string exampleDescription = "Task desc";
        private readonly DateTime date2010 = new DateTime(2010, 1, 1,10,0,0);
        private readonly DateTime date2012 = new DateTime(2012, 1, 1,10,0,0);
        private readonly DateTime date2014 = new DateTime(2014, 1, 1,10,0,0);
        private readonly DateTime date2016 = new DateTime(2016, 1, 1,10,0,0);

        [Fact]
        public void SetEmptyDesc()
        {
            TaskModel tm = new TaskModel(exampleDescription, date2010);
            Assert.Throws<ArgumentException>(() => tm.Description = "   ");
        }

        [Fact]
        public void SetEndBeforeStart()
        {
            TaskModel tm = new TaskModel(exampleDescription, date2016);
            Assert.Throws<ArgumentException>(() => tm.EndDate = date2010);
        }

        [Fact]
        public void SetStartDateAfterEnd()
        {
            TaskModel tm = new TaskModel(exampleDescription, date2010, date2012);
            TimeSpan span = tm.EndDate - tm.StartDate;
            tm.StartDate = date2014;
            TimeSpan spanAfterUpdate = tm.EndDate - tm.StartDate;
            Assert.Equal(span, spanAfterUpdate);
        }

        [Fact]
        public void SetSameStartDate()
        {
            TaskModel tm = new TaskModel(exampleDescription, date2010, date2012);
            Assert.False(tm.AllDay);
            tm.StartDate = tm.EndDate;
            Assert.True(tm.AllDay);
        }

        [Fact]
        public void SetSameEndDate()
        {
            TaskModel tm = new TaskModel(exampleDescription, date2010, date2012);
            Assert.False(tm.AllDay);
            tm.EndDate = tm.StartDate;
            Assert.True(tm.AllDay);
        }

        [Fact]
        public void InitializaAsAllDay()
        {
            TaskModel tm = new TaskModel(exampleDescription, date2010);
            Assert.True(tm.AllDay);
        }
    }
}
