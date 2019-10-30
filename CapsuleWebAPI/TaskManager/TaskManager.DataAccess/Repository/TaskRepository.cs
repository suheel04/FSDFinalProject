using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entities;

namespace TaskManager.DataAccess.Repository
{
    public class TaskRepository
    {
        public List<TaskDetail> GetTaks()
        {
            TaskManagerDBContext taskManagerDBContext = new TaskManagerDBContext();
            return taskManagerDBContext.TaskDetails.ToList();
        }
    }
}
