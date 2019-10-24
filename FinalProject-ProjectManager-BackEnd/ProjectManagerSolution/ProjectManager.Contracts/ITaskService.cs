using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Entities;

namespace ProjectManager.Contracts
{
    public interface ITaskService
    {
        IEnumerable<TaskDetailEntity> GetAllTask();
        TaskDetailEntity GetTask(int TaskID);
        int AddTask(TaskDetailEntity task);
        int UpdateTask(TaskDetailEntity task);
        
        int EndTask(int ID);

        int DeleteTask(int ID);

    }
}
