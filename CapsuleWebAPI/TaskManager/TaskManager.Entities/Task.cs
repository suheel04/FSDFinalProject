using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TaskManager.Entities
{
    [Table("Task", Schema ="dbo")]
    public class TaskDetail
    {
        [Key]
        public int TaskID { get; set; }
        public int? ParentID { get; set; }
        [ForeignKey(name: "ParentID")]
        public TaskDetail ParentTask { get; set; }
        [MaxLength(150)]
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }
        public bool IsCompleted { get; set; }
    }
}
