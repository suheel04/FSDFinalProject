using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entities;

namespace TaskManager.Contracts
{
    public interface ITaskService
    {
        IEnumerable<TaskEntity> GetAllTask();
        TaskEntity GetTask(int TaskID);
        int AddTask(TaskEntity task);
        int UpdateTask(TaskEntity task);

        int EndTask(int ID);

        int DeleteTask(int ID);

    }
}
