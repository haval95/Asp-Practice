using Core.Model;
using DataStore.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//using practice.Model;

using System.Linq;


namespace practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly BugsContext _db;
        public ProjectsController(BugsContext db)
        {
            _db = db;
        }
        // GET: api/<ProjectsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Projects.ToList());
        }

        // GET api/<ProjectsController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _db.Projects.Find(id);
            if(project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        // POST api/<ProjectsController>
        [HttpPost]
        public IActionResult Post([FromBody] Project  project)
        {
            _db.Projects.Add(project);
            _db.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = project.ProjectId }, project);
          
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody] Project project)
        {

            if (project.ProjectId != id) return BadRequest();

            _db.Entry(project).State = EntityState.Modified;
            try
            {
                _db.SaveChanges();
            }
            catch
            {
                if (_db.Projects.Find(id) == null)
                    return NotFound();
                throw;
            }

            return NoContent();
        }


        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var project = _db.Projects.Find(id);
            if (project != null)
            {
                _db.Projects.Remove(project);
                _db.SaveChanges();
                return Ok();
            }

            return NotFound();
         
        }

        [HttpGet]
        //here we overwrite the class route by re-initiating the route, BUT we need to have the first / otherwise its going to be added after the class route 
        [Route("/api/projects/{pid}/tickets")]
        public IActionResult GetProjectTicket (int pid)
        {
            var tickets = _db.Tickets.Where(t => t.ProjectId == pid).ToList();
            if(tickets.Count == 0)
            {
                return NotFound();
            }
            return Ok(tickets);

        }


    }
}
