using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Entities
{
    public class TaskDetailEntity
    {
        public int TaskID { get; set; }
        public int? ParentID { get; set; }   
        public string TaskName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public bool IsCompleted { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }

        public TaskDetailEntity ParentTask { get; set; }

        public ProjectEntity Project { get; set; }

        public string ParentTaskName
        {
            get { return ParentTask == null ? string.Empty : ParentTask.TaskName; }
        }

        public string ProjectName
        {
            get { return Project == null ? string.Empty : Project.ProjectName; }
        }



    }


    public class Task
    {
        public int TaskID { get; set; }
        public int? ParentID { get; set; }
        public string TaskName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public bool IsCompleted { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }
        
        public string ParentTaskName
        {
            get; set;
        }

        public string ProjectName
        {
            get; set;
        }


    }
}
