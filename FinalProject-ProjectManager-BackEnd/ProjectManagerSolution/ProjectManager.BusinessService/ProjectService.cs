using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManager.Entities;
using ProjectManager.Contracts;
using ProjectManager.DataAccess.UnitOfWork;
using AutoMapper;
using System.Linq;
using System;

namespace ProjectManager.BusinessService
{
    public class ProjectService : IProjectService
    {
        private UnitOfWork _unitOfWork = null;
        public ProjectService()
        {
            _unitOfWork = new UnitOfWork();
        }
        public int AddProject(ProjectEntity projectEntity)
        {
            var projectModel = Mapper.Map<Project>(projectEntity);
            _unitOfWork.ProjectRepository.Insert(projectModel);
            return _unitOfWork.Save();
        }

        public IEnumerable<ProjectEntity> GetAllProjects()
        {
            var projectModel = _unitOfWork.ProjectRepository.GetAll();
            var taskList = new TaskService().GetAllTask();
            if (projectModel != null)
            {
                var projectEntity = Mapper.Map<IEnumerable<ProjectEntity>>(projectModel);
                foreach (var project in projectEntity)
                {
                    var count = taskList.Where(x => x.UserID == project.UserID).Count();
                    project.TaskCount = count;
                }
                return projectEntity;
            }
            return null;
        }

        public ProjectEntity GetProject(int projectID)
        {
            Project projectModel = _unitOfWork.ProjectRepository.GetSingle(x => x.ProjectID == projectID);
            if (projectModel != null)
            {
                var projectEntity = Mapper.Map<ProjectEntity>(projectModel);
                return projectEntity;
            }
            return null;
        }

        public int DeleteProject(int ID)
        {
           _unitOfWork.ProjectRepository.Delete(ID);
            return _unitOfWork.Save();
        }

        public int UpdateProject(ProjectEntity projectEntity)
        {
            var projectModel = _unitOfWork.ProjectRepository.GetByID(projectEntity.ProjectID);
            projectModel.ProjectName = projectEntity.ProjectName;
            projectModel.EndDate = projectEntity.EndDate;
            projectModel.StartDate = projectEntity.StartDate;
            projectModel.Priority = projectEntity.Priority;
            projectModel.UserID = projectEntity.UserID;
            projectModel.IsActive = true;
            _unitOfWork.ProjectRepository.Update(projectModel);
            return _unitOfWork.Save();
        }

        public int SuspendProject(int projectID)
        {
            var projectModel = _unitOfWork.ProjectRepository.GetByID(projectID);
            projectModel.IsActive = false;
            _unitOfWork.ProjectRepository.Update(projectModel);
            return _unitOfWork.Save();
        }
    }
}
