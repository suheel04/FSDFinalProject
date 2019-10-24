using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Entities
{
    public class ProjectEntity
    {
        public int ProjectID { get; set; }

        public string ProjectName { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
        public bool IsComplete { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }
        public int TaskCount { get; set; }

        public ICollection<TaskDetailEntity> TaskDetails { get; set; }
    }
}
