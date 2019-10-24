using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Entities
{
    public class UserEntity
    {
        public int UserID { get; set; }
        public String FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeeID { get; set; }

        public ICollection<ProjectEntity> ProjectEntities { get; set; }
        public ICollection<TaskDetailEntity> TaskDetails { get; set; }
    }
}
