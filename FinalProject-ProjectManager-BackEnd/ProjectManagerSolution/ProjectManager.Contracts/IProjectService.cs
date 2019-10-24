using ProjectManager.Entities;
using System.Collections.Generic;

namespace ProjectManager.Contracts
{
    public interface IProjectService
    {
        IEnumerable<ProjectEntity> GetAllProjects();
        ProjectEntity GetProject(int projectID);
        int AddProject(ProjectEntity projectEntity);
        int UpdateProject(ProjectEntity projectEntity);
        int SuspendProject(int projectID);

    }
}
