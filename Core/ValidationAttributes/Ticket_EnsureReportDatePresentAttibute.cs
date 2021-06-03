using System.ComponentModel.DataAnnotations;
using Core.Model;

namespace Core.ValidationAttributes
{
    public class Ticket_EnsureReportDatePresentAttibute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var ticket = validationContext.ObjectInstance   as Ticket;

            if (!ticket.ValidateReportDatePresence())
            {
                return new ValidationResult("Report date is Required.");
            }

            return ValidationResult.Success;

        }
    }
}
