using System;
using System.Linq;
using NUnit.Framework;
using ProjectManager.Contracts;
using ProjectManager.Entities;
using ProjectManager.BusinessService;


namespace ProjectManager.Test
{
    [TestFixture]
    public class ProjectServiceTest
    {
        ProjectService _service;
        public ProjectServiceTest()
        {
            _service = new ProjectService();
        }
        [SetUp]
        public void SetUp()
        {
            AutoMapperConfig.Initialize();
        }
        [Test]
        public void GetAllProject()
        {
            var projectList = _service.GetAllProjects();
            Assert.IsNotNull(projectList);
            Assert.IsInstanceOf(typeof(ProjectEntity), projectList.FirstOrDefault());
        }
        [Test]
        public void GetProject()
        {
            var projectList = _service.GetAllProjects().FirstOrDefault();
            var project = _service.GetProject(projectList.ProjectID);
            Assert.IsNotNull(project);
            Assert.IsInstanceOf(typeof(ProjectEntity), project);
            Assert.AreEqual(project.ProjectID, projectList.ProjectID);
        }
        //[Test]
        //public void AddProject()
        //{
        //    var addEntity = new ProjectEntity
        //    {
        //        ProjectName = "NUnitProject",
        //        StartDate = DateTime.Today,
        //        EndDate = DateTime.Today,
        //        IsActive = true,
        //        IsComplete = false,
        //        Priority = 5,
        //        UserID = 2
        //    };

        //    var value = _service.AddProject(addEntity);
        //    Assert.IsTrue(value > 0);
        //}
        [Test]
        public void UpdateProject()
        {
            var updateEntity = _service.GetAllProjects().Where(x => x.Priority != 5).FirstOrDefault();
            if (updateEntity != null)
            {
                updateEntity.Priority = 5;
                var value = _service.UpdateProject(updateEntity);
                var resultTask = _service.GetProject(updateEntity.ProjectID);
                Assert.IsTrue(value > 0);
                Assert.IsTrue(resultTask.Priority == 5);

            }
            else
            {
                Assert.Ignore();
            }
        }
    }
}
