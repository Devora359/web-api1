using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Services;
using Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IclassService classService;


        //The assignment asks the users controller to take the password service's interface and call it: where should this controller get the password service?
        public UsersController(IclassService classService)
        {
            this.classService = classService;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        string filePath = "file.txt";

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return Ok(classService.GetUserById(id));
        }
        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            //Where is the password checked? The assignment asks a weak password (score below 3) to return 400 here, before the user is added
            user= classService.AddUser(user);
            return CreatedAtAction(nameof(Get), new { id = user.userId },
            user);

        }

        [HttpPost("login")]
        public ActionResult<User> Post([FromBody] userLogin loginUser)
        {
           
            if (classService.AddUserLogin(loginUser) != null)
                return Ok(classService.AddUserLogin(loginUser));
            //The assignment asks login with a wrong password to return 204 (NoContent): what should this return instead of NotFound?
            return NotFound();

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        //The assignment asks PUT to return Ok(): change void to IActionResult and return Ok() at the end
        public void Put(int id, [FromBody] User userToUpdate)
        {
            //Where is the password checked before the update? The assignment asks a weak password (score below 3) to return 400
            classService.updateUser(id, userToUpdate);

        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
