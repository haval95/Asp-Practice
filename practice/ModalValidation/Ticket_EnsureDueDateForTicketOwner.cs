/*using practice.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace practice.ModalValidation
{
    public class Ticket_EnsureDueDateForTicketOwner: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;
            if(ticket != null && !string.IsNullOrWhiteSpace(ticket.Owner))
            {
                if (!ticket.DueDate.HasValue)
                {
                    return new ValidationResult("Due Date is Required when we have owner ");
                }
             
            }
            return ValidationResult.Success;
        }
    }
}
*/