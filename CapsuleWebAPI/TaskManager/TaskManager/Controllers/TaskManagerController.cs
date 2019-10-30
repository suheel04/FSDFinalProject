using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using TaskManager.Entities;
using TaskManager.BusinessService;
using TaskManager.Contracts;

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
        // GET: api/TaskManager
        [HttpGet]
        public IHttpActionResult GetTask()
        {
            var tasks = _TaskService.GetAllTask().ToList();
            if (tasks != null)
            {
                return Ok(tasks);
            }

            return NotFound();
        }

        // GET: api/TaskManager/5
        public IHttpActionResult GetTask(int taskID)
        {
            var task = _TaskService.GetTask(taskID);
            if (task != null)
            {
                return Ok(task);
            }

            return NotFound();
        }

        // POST: api/TaskManager
        [HttpPost]
        [Route("TaskEntity")]
        public IHttpActionResult TaskEntity(TaskEntity task)
        {
            int success = _TaskService.AddTask(task);
            return Ok(success);
        }

        // PUT: api/TaskManager/5
        [HttpPut]
        public IHttpActionResult UpdateTask(TaskEntity Task)
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
