using Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Model
{
   public class Project
    {
        public int ProjectId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
