using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entities;
using TaskManager.Contracts;
using TaskManager.DataAccess.UnitOfWork;
using AutoMapper;

namespace TaskManager.BusinessService
{
    public class TaskService : ITaskService
    {
        private UnitOfWork _unitOfWork = null;
        public TaskService()
        {
            _unitOfWork = new UnitOfWork();
        }
        public int AddTask(TaskEntity task)
        {
            var taskModel = Mapper.Map<Entities.TaskDetail>(task);
            _unitOfWork.TaskRepository.Insert(taskModel);
            return _unitOfWork.Save();

        }

        public IEnumerable<TaskEntity> GetAllTask()
        {
            var taskModel = _unitOfWork.TaskRepository.GetAll();
            if (taskModel != null)
            {
                var taskEntity = Mapper.Map<IEnumerable<TaskEntity>>(taskModel);
                return taskEntity;
            }
            return null;
        }

        public TaskEntity GetTask(int TaskID)
        {
            Entities.TaskDetail taskModel = _unitOfWork.TaskRepository.GetSingle(x => x.TaskID == TaskID);
            if (taskModel != null)
            {
                var taskEntity = Mapper.Map<TaskEntity>(taskModel);
                return taskEntity;
            }
            return null;
        }

        public int UpdateTask(TaskEntity task)
        {

            var taskModel = _unitOfWork.TaskRepository.GetByID(task.TaskID);
            taskModel.TaskName = task.TaskName;
            taskModel.ParentID = task.ParentID;
            taskModel.EndDate = task.EndDate;
            taskModel.StartDate = task.StartDate;
            taskModel.Priority = task.Priority;
            _unitOfWork.TaskRepository.Update(taskModel);
            return _unitOfWork.Save();
        }

        public int EndTask(int ID)
        {
            var completeTask = _unitOfWork.TaskRepository.GetByID(ID);
            if (completeTask != null)
                completeTask.IsCompleted = true;
            _unitOfWork.TaskRepository.Update(completeTask);
            return _unitOfWork.Save();
        }

        public int DeleteTask(int ID)
        {
            _unitOfWork.TaskRepository.Delete(ID);
            return _unitOfWork.Save();
        }
    }
}
