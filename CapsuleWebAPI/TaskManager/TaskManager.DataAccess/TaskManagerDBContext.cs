using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entities;

namespace TaskManager.DataAccess
{
    public class TaskManagerDBContext: DbContext
    {
        public DbSet<TaskDetail> TaskDetails { get; set; }
    }
}
