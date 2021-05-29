using Microsoft.AspNetCore.Mvc;
using practice.Filtters;
using practice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
       // [Route("api/tickets")] we have this if we dont have the route for the class 
       
        public IActionResult Get()
        {
            return Ok("reading all the tickets" );

        }

        [HttpGet("{id}")]
       // [Route("api/ticket/{id}")] we would need this without the class route but now we can remove this and the ID to the Http verb attribute 
        public IActionResult Get(int id)
        {
            return Ok($"Reading one ticket: #{id} ");
        }

        [HttpPost]

        public IActionResult Post([FromBody] Ticket tiket)
        {
            return Ok(tiket);
        }

        [HttpPost]
        [Route("/api/v2/tickets")]
        [Ticket_EnsureEnterDate]
        public IActionResult PostV2([FromBody] Ticket tiket)
        {
            return Ok(tiket);
        }
        [HttpPut]
     
        public IActionResult Put()
        {
            return Ok("Updating A ticket ");
        }


        [HttpDelete("{id}")]
      
        public IActionResult Delete(int id )
        {
            return Ok($"deleting one ticket: #{id} ");
        }
    }
}
