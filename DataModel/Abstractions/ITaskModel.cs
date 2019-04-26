using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Abstractions
{
    public interface ITaskModel
    {
        string Name { get; set; }
        string Description { get; set; }

        bool Important { get; set; }
        bool AllDay { get; set; }

        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
