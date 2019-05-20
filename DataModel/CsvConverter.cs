using DataModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class CsvConverter : IConverter
    {
        private ITaskBuilder _taskBuilder;

        public CsvConverter(ITaskBuilder taskBuilder)
        {
            _taskBuilder = taskBuilder;
        }

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

        public IEnumerable<ITaskModel> FromStringArray(string[] source)
        {
            List<ITaskModel> result = new List<ITaskModel>();
            foreach(string taskString in source)
            {
                string[] splitString = taskString.Split(',');
                if(splitString.Length == 5)
                {
                    var task =_taskBuilder.BuildTask(splitString[0].Trim('"'), splitString[1].Trim('"'), DateTime.Parse(splitString[2].Trim('"')), DateTime.Parse(splitString[3].Trim('"')), splitString[4].ToLower() == "true" ? true : false);
                    result.Add(task);
                }                
            }
            return result;
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
