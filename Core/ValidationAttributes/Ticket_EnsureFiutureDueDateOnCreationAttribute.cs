using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using practice.Model;

namespace Core.ValidationAttributes
{
    public class Ticket_EnsureFiutureDueDateOnCreationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var ticket = validationContext.ObjectInstance   as Ticket;

            if (!ticket.ValidateFutureDueDate())
            {
                return new ValidationResult("Due date must be in the future .");
            }

            return ValidationResult.Success;

        }
    }
}
