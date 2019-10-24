using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Entities
{
    [Table("Project", Schema = "dbo")]
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        
        public string ProjectName { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }

        public bool IsActive { get; set; }
         
        public int UserID { get; set; }
        public User User { get; set; }
        
        public ICollection<TaskDetail> TaskDetails { get; set; }
    }
}
