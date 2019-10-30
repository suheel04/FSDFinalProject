using System;
using System.Linq;
using NUnit.Framework;
using TaskManager.BusinessService;
using TaskManager.Contracts;
using TaskManager.Entities;

namespace TaskManager.Test
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
        public void GetAllTaskTest()
        {
            var taskList = _TaskService.GetAllTask();
            Assert.IsNotNull(taskList);
            Assert.IsInstanceOf(typeof(TaskEntity), taskList.FirstOrDefault());
        }
        [Test]
        public void GetTaskTest()
        {
            var taskList = _TaskService.GetAllTask();
            Assert.IsNotNull(taskList);
            Assert.IsInstanceOf(typeof(TaskEntity), taskList.FirstOrDefault());
        }
        [Test]
        public void AddTaskTest()
        {
            var addTaskEntity = new TaskEntity { TaskName = "TestTask", EndDate = DateTime.Today, IsCompleted = false, ParentID = null, Priority = 4, StartDate = DateTime.Today };

            var value = _TaskService.AddTask(addTaskEntity);
            Assert.IsTrue(value > 0);
        }
        [Test]
        public void UpdateTaskTest()
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
        public void EndTaskTest()
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
