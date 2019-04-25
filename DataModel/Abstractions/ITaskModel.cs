using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Abstractions
{
    public interface ITaskModel
    {
        string Description { get; set; }

        bool Important { get; set; }
        bool AllDay { get; }

        DateTime StartDate { get; set; }
        DateTime? EndDate { get; set; }

        void SetAllDay();
    }
}
