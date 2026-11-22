using Microsoft.AspNetCore.Mvc;
using Services;
using Zxcvbn;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //In C#, class names are written in PascalCase: PasswordController. The file should also be named PasswordController.cs
    public class passwordController : ControllerBase
    {


        IStromgPassService stromgPassService;

        public passwordController(IStromgPassService stromgPassService)
        {
            this.stromgPassService= stromgPassService;
        }
        // GET: api/<passwordController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<passwordController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<passwordController>
        [HttpPost]

        public IActionResult Post([FromBody] string password)
        {
        
            return Ok(stromgPassService.GetStrongPass(password));

        }

        // PUT api/<passwordController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<passwordController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
