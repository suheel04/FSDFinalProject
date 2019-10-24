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
    public class UserManagerController : ApiController
    {
        IUserService _service = null;
        UserManagerController()
        {
            _service = new UserService();
        }
        [HttpGet]
        [Route("api/UserManager/GetUser")]
        public IHttpActionResult GetUser()
        {
            var users = _service.GetAllUsers().ToList();
            if (users != null)
            {
                return Ok(users);
            }

            return NotFound();
        }

        // GET: api/TaskManager/5
        [HttpPost]
        [Route("api/UserManager/GetUser")]
        public IHttpActionResult GetUser(int userID)
        {
            var user = _service.GetUser(userID);
            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        // POST: api/TaskManager
        public IHttpActionResult Post(UserEntity user)
        {
            int success = _service.AddUser(user);
            return Ok(success);
        }

        // PUT: api/TaskManager/5
        [HttpPut]
        public IHttpActionResult UpdateUser(UserEntity user)
        {

            int success = _service.UpdateUser(user);
            return Ok(success);
        }
        [HttpGet]
        public IHttpActionResult DeleteUser(int deleteID)
        {
            int success = _service.DeleteTask(deleteID);
            return Ok("tesd");
        }
    }
}
