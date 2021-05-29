using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using practice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice.Filtters
{
    public class Ticket_EnsureEnterDate: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            
            var ticket = context.ActionArguments["tiket"] as Ticket;
            if(ticket != null && !string.IsNullOrWhiteSpace(ticket.Owner) && ticket.EnterDate.HasValue == false)
            {
                context.ModelState.AddModelError("Enter Date", "Enter date is required");
                context.Result = new BadRequestObjectResult(context.ModelState);
                    
            }
        }
    }
}
