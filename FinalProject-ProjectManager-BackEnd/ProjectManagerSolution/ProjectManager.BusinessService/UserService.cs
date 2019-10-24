using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManager.Entities;
using ProjectManager.Contracts;
using ProjectManager.DataAccess.UnitOfWork;
using AutoMapper;
using System;
using System.Linq;

namespace ProjectManager.BusinessService
{
    public class UserService : IUserService
    {
        private UnitOfWork _unitOfWork = null;
        public UserService()
        {
            _unitOfWork = new UnitOfWork();
        }
        public int AddUser(UserEntity userEntity)
        {
            var user = Mapper.Map<User>(userEntity);
            _unitOfWork.UserRepository.Insert(user);
            return _unitOfWork.Save();
        }

        public int DeleteTask(int ID)
        {
            TaskService taskService = new TaskService();
            ProjectService projectService = new ProjectService();
            var lstTasks = taskService.GetAllTask().Where(x => x.UserID == ID).Select(x => x);
            if (lstTasks != null && lstTasks.Count() > 0)
            {
                foreach (var task in lstTasks)
                {
                    taskService.DeleteTask(task.TaskID);


                }
            }
            var lstProject = projectService.GetAllProjects().Where(x => x.UserID == ID).Select(x => x);
         
            if (lstProject != null && lstProject.Count() > 0)
            {
                foreach (var project in lstProject)
                {
                    projectService.DeleteProject(project.ProjectID);
                                     

                }
            }
            

            _unitOfWork.UserRepository.Delete(ID);
            return _unitOfWork.Save();
        }

        public IEnumerable<UserEntity> GetAllUsers()
        {
            var userModel = _unitOfWork.UserRepository.GetAll();
            if (userModel != null)
            {
                var userEntity = Mapper.Map<IEnumerable<UserEntity>>(userModel);
                return userEntity;
            }
            return null;
        }

        public UserEntity GetUser(int userID)
        {
            User userModel = _unitOfWork.UserRepository.GetSingle(x => x.UserID == userID);
            if (userModel != null)
            {
                var userEntity = Mapper.Map<UserEntity>(userModel);
                return userEntity;
            }
            return null;
        }

        public int UpdateUser(UserEntity userEntity)
        {
            var userModel = _unitOfWork.UserRepository.GetByID(userEntity.UserID);
            userModel.FirstName = userEntity.FirstName;
            userModel.LastName = userEntity.LastName;
            userModel.EmployeeID = userEntity.EmployeeID;            
            _unitOfWork.UserRepository.Update(userModel);
            return _unitOfWork.Save();
        }
    }
}
