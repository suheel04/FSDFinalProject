using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using ProjectManager.Entities;
using ProjectManager.BusinessService;
using ProjectManager.Contracts;


namespace ProjectManager.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectManagerController : ApiController
    {
        IProjectService _service = null;
        ProjectManagerController()
        {
            _service = new ProjectService();
        }
        [HttpGet]
        [Route("api/UserManager/GetProject")]
        public IHttpActionResult GetProject()
        {
            var projects = _service.GetAllProjects().ToList();
            if (projects != null)
            {
                return Ok(projects);
            }

            return NotFound();
        }

        // GET: api/TaskManager/5
        public IHttpActionResult GetProject(int projectID)
        {
            var project = _service.GetProject(projectID);
            if (project != null)
            {
                return Ok(project);
            }

            return NotFound();
        }

        // POST: api/TaskManager
        public IHttpActionResult Post(ProjectEntity project)
        {
            int success = _service.AddProject(project);
            return Ok(success);
        }

        // PUT: api/TaskManager/5
        [HttpPut]
        public IHttpActionResult UpdateProject(ProjectEntity project)
        {

            int success = _service.UpdateProject(project);
            return Ok(success);
        }

        [HttpGet]
        public IHttpActionResult SuspendProject(int suspendProjectID)
        {
            int success = _service.SuspendProject(suspendProjectID);
            return Ok(success);
        }
    }
}
