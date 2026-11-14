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
            user= classService.AddUser(user);
            return CreatedAtAction(nameof(Get), new { id = user.userId },
            user);

        }

        [HttpPost("login")]
        public ActionResult<User> Post([FromBody] userLogin loginUser)
        {
           
            if (classService.AddUserLogin(loginUser) != null)
                return Ok(classService.AddUserLogin(loginUser));
            //The assignment asks a wrong login to return 204 NoContent: what should this return instead of NotFound?
            return NotFound();

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        //The assignment asks PUT to return Ok(): change void to IActionResult and return Ok() at the end
        public void Put(int id, [FromBody] User userToUpdate)
        {
            classService.updateUser(id, userToUpdate);

        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
