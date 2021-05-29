using practice.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    class Project
    {
        public int ProjectId { get; set; }

        public string Name { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
