using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Abstractions
{
    public interface IConverter
    {
        string[] ToStringArray(IEnumerable<ITaskModel> source);
    }
}
