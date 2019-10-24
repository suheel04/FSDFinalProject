using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Entities;

namespace ProjectManager.DataAccess.Repository
{
    public class TaskRepository
    {
        public List<TaskDetail> GetTaks()
        {
            ProjectManagerDBContext projectManagerDBContext = new ProjectManagerDBContext();
            return projectManagerDBContext.TaskDetails.ToList();
        }
    }
}
