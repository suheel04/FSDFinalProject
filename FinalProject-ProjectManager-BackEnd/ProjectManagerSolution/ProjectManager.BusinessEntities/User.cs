using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectManager.Entities
{
    [Table("User", Schema = "dbo")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [MaxLength(150)]
        public String FirstName { get; set; }
        [MaxLength(150)]
        public string LastName { get; set; }
        public int EmployeeID { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<TaskDetail> TaskDetails { get; set; }

    }
}
