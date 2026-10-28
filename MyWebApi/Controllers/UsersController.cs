 
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        //Why isn't it implemented? It should read the file and return the user with this id (or NotFound / NoContent)
        public string Get(int id)
        {
            return "value";
        }
        //fix: The path never changes, so it can be readonly
        readonly string filePath = "file.txt";
        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.userId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson +
            Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.userId },
            user);

        }

        //The assignment asks a wrong login to return NoContent() (204)
        [HttpPost("login")]
        public ActionResult<User> Post([FromBody] userLogin loginUser)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.email == loginUser.email && user.password ==
                    loginUser.password)
                        return Ok(user);
                }
            }
            return NotFound();

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        //The assignment asks PUT to return Ok(): change void to IActionResult and return Ok() at the end
        //fix: The project didn't build: userToUpdate was used below but didn't exist. PUT receives the updated user
        public void Put(int id, [FromBody] User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader =
            System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.userId == id)
                    {
                        textToReplace = currentUserInFile;
                        //fix: Found- break
                        break;
                    }
                }
            }
           
                   if(textToReplace != string.Empty)
{
                //fix: Keep the id, otherwise the updated user is saved without it
                userToUpdate.userId = id;
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(filePath, text);
            }

        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
