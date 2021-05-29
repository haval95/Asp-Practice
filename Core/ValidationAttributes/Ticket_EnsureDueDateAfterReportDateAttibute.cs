using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using practice.Model;

namespace Core.ValidationAttributes
{
    public class Ticket_EnsureDueDateAfterReportDateAttibute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var ticket = validationContext.ObjectInstance   as Ticket;

            if (!ticket.validateDueDateAfterReportDay ())
            {
                return new ValidationResult("Due date must be after Report date.");
            }

            return ValidationResult.Success;

        }
    }
}
