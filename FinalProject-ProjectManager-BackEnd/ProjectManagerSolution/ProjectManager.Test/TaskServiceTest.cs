using System;
using System.Linq;
using NUnit.Framework;
using ProjectManager.Contracts;
using ProjectManager.Entities;
using ProjectManager.BusinessService;

namespace ProjectManager.Test
{
    [TestFixture]
    public class TaskServiceTest
    {
        TaskService _TaskService;
        [SetUp]
        public void SetUp()
        {
            AutoMapperConfig.Initialize();
        }

        [Test]
        public void GetAllTask()
        {
            var taskList = _TaskService.GetAllTask();
            Assert.IsNotNull(taskList);
            Assert.IsInstanceOf(typeof(TaskDetailEntity), taskList.FirstOrDefault());
        }
        [Test]
        public void GetTask()
        {
            var taskList = _TaskService.GetAllTask().FirstOrDefault();
            var task = _TaskService.GetTask(taskList.TaskID);
            Assert.IsNotNull(task);
            Assert.IsInstanceOf(typeof(TaskDetailEntity), task);
            Assert.AreEqual(task.TaskID, taskList.TaskID);
        }
        //[Test]
        //public void AddTask()
        //{
        //    var addTaskEntity = new TaskDetailEntity { TaskName = "NUnitTask",
        //        EndDate = DateTime.Today,
        //        IsCompleted = false,
        //        ParentID = null,
        //        Priority = 4,
        //        StartDate = DateTime.Today,
        //        ProjectID =2,
        //    UserID=2};

        //    var value = _TaskService.AddTask(addTaskEntity);
        //    Assert.IsTrue(value > 0);
        //}
        [Test]
        public void UpdateTask()
        {
            var updateTaskEntity = _TaskService.GetAllTask().Where(x=>x.Priority != 5).FirstOrDefault();
            if(updateTaskEntity != null){
                updateTaskEntity.Priority = 5;
                var value = _TaskService.UpdateTask(updateTaskEntity);
                var resultTask = _TaskService.GetTask(updateTaskEntity.TaskID);
                Assert.IsTrue(value > 0);
                Assert.IsTrue(resultTask.Priority == 5);
            
            }
            else
            {
                Assert.Ignore();
            }

        }
        [Test]
        public void EndTask()
        {
            var updateTaskEntity = _TaskService.GetAllTask().Where(x => x.IsCompleted == false).FirstOrDefault();
            if (updateTaskEntity != null)
            {
                var value = _TaskService.EndTask(updateTaskEntity.TaskID);
                var resultTask = _TaskService.GetTask(updateTaskEntity.TaskID);
                Assert.IsTrue(value > 0);
                Assert.IsTrue(resultTask.IsCompleted);
            }
            else
            {
                Assert.Ignore();
            }

        }

        public TaskServiceTest()
        {
            _TaskService = new TaskService();
        }

         
    }
}
