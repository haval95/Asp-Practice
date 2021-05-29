/* using practice.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace practice.ModalValidation
{
    public class Ticket_DueDateIsNotInPast: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;

            if(ticket != null )
            {
                if(ticket.DueDate.HasValue && ticket.DueDate.Value < DateTime.Now)
                {
                    return new ValidationResult("Due date must be in the future");
                }
            }
            return ValidationResult.Success;
        }
    }
}
*/