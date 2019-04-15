using System;
using Xunit;

namespace DataModel.Tests
{
    public class TaskModelTests
    {
        private const string exampleDescription = "Task desc";
        private readonly DateTime date2010 = new DateTime(2010, 1, 1);
        private readonly DateTime date2012 = new DateTime(2012, 1, 1);
        private readonly DateTime date2014 = new DateTime(2014, 1, 1);
        private readonly DateTime date2016 = new DateTime(2016, 1, 1);

        private TimeSpan Time2016_2010 => date2016 - date2010;

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
    }
}
