using System.ComponentModel.DataAnnotations;
using Core.Model;
namespace Core.ValidationAttributes
{
    public class Ticket_EnsureDueDatePresentAttiute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var ticket = validationContext.ObjectInstance   as Ticket;

            if (!ticket.ValidateDueDatePresence())
            {
                return new ValidationResult("Due date Required.");
            }

            return ValidationResult.Success; 

        }
    }
}
