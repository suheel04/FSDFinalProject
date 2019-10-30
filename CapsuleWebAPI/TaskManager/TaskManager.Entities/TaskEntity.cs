using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Entities
{
    public class TaskEntity
    {
        public int TaskID { get; set; }
        public int? ParentID { get; set; }
        public string TaskName { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }
        public bool IsCompleted { get; set; }

        public TaskEntity ParentTask { get; set; }

        public string ParentTaskName
        {
            get { return ParentTask == null ? string.Empty : ParentTask.TaskName; }
        }



    }
}
