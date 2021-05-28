using Microsoft.AspNetCore.Mvc;
using practice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        // GET: api/<ProjectsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Get all Projects ");
        }

        // GET api/<ProjectsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"Reading  project: #{id} ");
        }

        // POST api/<ProjectsController>
        [HttpPost]
        public IActionResult Post([FromBody] Ticket tiket)
        {
            return Ok(tiket);
        }

        [HttpPut]

        public IActionResult Put(int id, [FromBody] Ticket tiket)
        {
            return Ok(tiket);
        }


        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            return Ok($"deleting one project: #{id}");
        }

        [HttpGet]
        //here we overwrite the class route by re-initiating the route, BUT we need to have the first / otherwise its going to be added after the class route 
        [Route("/api/projects/{pid}/tickets")]
        public IActionResult GetProjectTicket (int pid, int tid)
        {
            return Ok($"project number #{pid} and ticket number #{tid}");

        }


    }
}
