using Core.Model;
using Core.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace practice.Model

{
    public class Ticket
    {
        public int? Id { get; set; }
        public string  Name { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int? ProjectId { get; set; }

        [Required]
        public string  Owner { get; set; }
        [Ticket_EnsureReportDatePresentAttibute]
        public DateTime? ReportDate { get; set; }
        [Ticket_EnsureDueDatePresentAttiute]
        [Ticket_EnsureFiutureDueDateOnCreation]
        [Ticket_EnsureDueDateAfterReportDateAttibute]
        public DateTime? DueDate { get; set; }

      //  public Project Project { get; set; }

        /// <summary>
        /// When Creating a ticket, if due date is entered it has to be in the future. 
        /// </summary>
      
        public bool ValidateFutureDueDate()
        {
            if (Id.HasValue) return true;
            if (!DueDate.HasValue) return true;

            return (DueDate.Value > DateTime.Now);

        }
        /// <summary>
        /// When Owner is assigned the report date has to be there as well
        /// </summary>
        /// <returns></returns>
        public bool ValidateReportDatePresence()
        {
            if (string.IsNullOrWhiteSpace(Owner)) return true;

            return ReportDate.HasValue;
        }
        /// <summary>
        /// When Owner is assigned the due date has to be there as well
        /// </summary>
        /// <returns></returns>
        public bool ValidateDueDatePresence()
        {
            if (string.IsNullOrWhiteSpace(Owner)) return true;

            return DueDate.HasValue;
        }

        /// <summary>
        /// when due date and report day are there, due date must be greater than report day
        /// </summary>
        /// <returns></returns>
        public bool validateDueDateAfterReportDay()
        {
            if (!DueDate.HasValue || !ReportDate.HasValue) return true;

            return DueDate.Value.Date > ReportDate.Value.Date;
        }
    }
}
