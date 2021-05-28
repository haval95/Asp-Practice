using practice.ModalValidation;
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
        public string  Owner { get; set; }
        [Ticket_DueDateIsNotInPast]
        [Ticket_EnsureDueDateForTicketOwner]
        public DateTime? DueDate { get; set; }    
    }
}
