/*using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice.Filtters
{
    public class Version1StoppingResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
           //we dont put anything here because we want the the filter run when request comming in not when going out
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (!context.HttpContext.Request.Path.Value.ToLower().Contains("v2"))
            {
                context.Result = new BadRequestObjectResult(
                    //this object is best practice but not required
                    new { 
                    vesioning = new[] { "this version is expired" }
                    }
                    );
            }
        }
    }
}
*/