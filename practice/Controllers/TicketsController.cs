using Microsoft.AspNetCore.Mvc;
//using practice.Filtters;
using Core.Model;
using DataStore.EF;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace practice.Controllers
{
    //HVL this tells asp this is an api controler and not an mvc controller
    [ApiController]
    //we can add [api/[controller]]
    //using tthis will help Mapcontroller Middleware to find the right controllers based on the URI
    //Adding the this will help us remove most of the routs that have the controler name
    [Route("api/[controller]")]
    //HVL we need to inhirit from controllerBase 
   // [Version1StoppingResourceFilter]
    public class TicketsController: ControllerBase
    {
        private readonly BugsContext _db;

        public TicketsController(BugsContext db)
        {
            _db = db;
        }
        [HttpGet]
       // [Route("api/tickets")] we have this if we dont have the route for the class 
       
        public IActionResult Get()
        {
            var tickets = _db.Tickets.ToList();
            return Ok(tickets);

        }

        [HttpGet("{id}")]
       // [Route("api/ticket/{id}")] we would need this without the class route but now we can remove this and the ID to the Http verb attribute 
        public IActionResult GetById(int id)
        {
            var ticket = _db.Tickets.Find(id);
            if(ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        [HttpPost]

        public IActionResult Post([FromBody] Ticket tiket)
        {

            _db.Tickets.Add(tiket);
            _db.SaveChanges();
            return CreatedAtAction(nameof(GetById),
                new { id= tiket.TicketId },tiket) ;
        }

        [HttpPost]
        [Route("/api/v2/tickets")]
       // [Ticket_EnsureEnterDate]
        public IActionResult PostV2([FromBody] Ticket tiket)
        {
            return Ok(tiket);
        }
        [HttpPut("{id}")]
     
        public IActionResult Put(int Id,[FromBody] Ticket tiket)
        {
            if (tiket.TicketId != Id) return BadRequest();

            _db.Entry(tiket).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch
            {
                if (_db.Tickets.Find(Id) == null) 
                    return NotFound();
                throw;
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
      
        public IActionResult Delete(int id )
        {
            var ticket = _db.Tickets.Find(id);

            if (ticket == null) return NotFound();
            _db.Tickets.Remove(ticket);
            _db.SaveChanges();
            return Ok();
        }
    }
}
