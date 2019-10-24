using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using ProjectManager.Entities;
using ProjectManager.BusinessService;
using ProjectManager.Contracts;

namespace TaskManager.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] 
    public class TaskManagerController : ApiController
    {
        ITaskService _TaskService = null;
        TaskManagerController()
        {
            _TaskService = new TaskService();
        }
        [HttpGet]
        [Route("api/TaskManager/GetTask")]
        public IHttpActionResult GetTask()
        {
            var tasks =  _TaskService.GetAllTask().ToList();
            if (tasks != null)
            {
                List<Task> lst = new List<Task>();
                foreach(TaskDetailEntity task in tasks)
                {
                    Task taskDetail = new Task();
                    taskDetail.EndDate = task.EndDate;
                    taskDetail.IsCompleted = task.IsCompleted;
                    taskDetail.ParentID = task.ParentID;
                    taskDetail.ParentTaskName = task.ParentTaskName;
                    taskDetail.Priority = task.Priority;
                    taskDetail.ProjectID = task.ProjectID;
                    taskDetail.ProjectName = task.ProjectName;
                    taskDetail.StartDate = task.StartDate;
                    taskDetail.TaskID = task.TaskID;
                    taskDetail.TaskName = task.TaskName;
                    taskDetail.UserID = task.UserID;

                    lst.Add(taskDetail);
                }
                return Ok(lst);
            }

            return NotFound();
        }

        // GET: api/TaskManager/5
        public IHttpActionResult GetTask(int taskID)
        {
            var task =  _TaskService.GetTask(taskID);
            if (task != null)
            {
                return Ok(task);
            }

            return NotFound();
        }

        // POST: api/TaskManager
        public IHttpActionResult Post(TaskDetailEntity task)
        {
            int success = _TaskService.AddTask(task);
            return Ok(success);
        }

        // PUT: api/TaskManager/5
        [HttpPut]
        public IHttpActionResult UpdateTask(TaskDetailEntity Task)
        {

            int success = _TaskService.UpdateTask(Task);
            return Ok(success);
        }


        [HttpDelete]
        public IHttpActionResult EndTask(int ID)
        {
            int success = _TaskService.EndTask(ID);
            return Ok(success);
        }
        [HttpGet]
        public IHttpActionResult DeleteTask(int deleteID)
        {
            int success = _TaskService.DeleteTask(deleteID);
            return Ok(success);
        }
    }
}
