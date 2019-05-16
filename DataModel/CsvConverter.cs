using DataModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class CsvConverter : IConverter
    {
        public string[] ToStringArray(IEnumerable<ITaskModel> source)
        {
            List<string> result = new List<string>();
            foreach(ITaskModel task in source)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendJoin(',', BuildPropertiesStrings(task));
                result.Add(sb.ToString());
            }
            return result.ToArray();
        }

        private string[] BuildPropertiesStrings(ITaskModel task)
        {
           return new string[] 
           {
               $"\u0022{task.Name}\u0022",
               $"\u0022{task.Description}\u0022",
               $"\u0022{task.StartDate.ToString()}\u0022",
               $"\u0022{task.EndDate.ToString()}\u0022",
               $"\u0022{task.Important.ToString()}\u0022"
           };
        }
    }
}
