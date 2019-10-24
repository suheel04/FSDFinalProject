using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManager.Entities;
using ProjectManager.Contracts;
using ProjectManager.DataAccess.UnitOfWork;
using AutoMapper;

namespace ProjectManager.BusinessService
{
    public class TaskService : ITaskService
    {
        private UnitOfWork _unitOfWork = null;
        public TaskService()
        {
            _unitOfWork = new UnitOfWork();       
        }
        public int AddTask(TaskDetailEntity task)
        {           
            var taskModel = Mapper.Map<TaskDetail>(task);
            _unitOfWork.TaskRepository.Insert(taskModel);
            return _unitOfWork.Save();
            
        }       

        public IEnumerable<TaskDetailEntity> GetAllTask()
        {
           var taskModel = _unitOfWork.TaskRepository.GetWithInclude((x) => x != null, "Project, User".Split(',')); 
            if (taskModel != null)
            {
                var taskEntity = Mapper.Map<IEnumerable<TaskDetailEntity>>(taskModel);
                return taskEntity;
            }
            return null;
        }

        public TaskDetailEntity GetTask(int TaskID)
        {
            TaskDetail taskModel = _unitOfWork.TaskRepository.GetSingle(x => x.TaskID == TaskID);
            if (taskModel != null)
            {               
                var taskEntity = Mapper.Map<TaskDetailEntity>(taskModel);
                return taskEntity;
            }
            return null;
        }

        public int UpdateTask(TaskDetailEntity task)
        {

            var taskModel = _unitOfWork.TaskRepository.GetByID(task.TaskID);
            taskModel.TaskName = task.TaskName;
            taskModel.ParentID = task.ParentID;
            taskModel.EndDate = task.EndDate;
            taskModel.StartDate = task.StartDate;
            taskModel.Priority = task.Priority;
            _unitOfWork.TaskRepository.Update(taskModel);
           return  _unitOfWork.Save();
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
