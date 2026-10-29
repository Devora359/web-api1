using Microsoft.AspNetCore.Mvc;
using Zxcvbn;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class passwordController : ControllerBase
    {
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
         

          

            int result = Zxcvbn.Core.EvaluatePassword(password).Score;
            return Ok(result);

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
