using Microsoft.EntityFrameworkCore;
using System;

using Core.Model;

namespace DataStore.EF
{
    public class BugsContext : DbContext  
    {
        //context is the representation of the database in the memory
        //and we use Dbset for creating the tables we have 
        public BugsContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //one project has many tickets, one ticket is in one project
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tickets)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId);

            //data seeding, fake data 

            modelBuilder.Entity<Project>().HasData(
                new Project { ProjectId = 1, Name = "project 1" },
                  new Project { ProjectId = 2, Name = "project 2" }
                );

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { TicketId=1, Description="describe", Name="hvl", ProjectId=1,Title="title 1"},
                new Ticket { TicketId = 2, Description = "describe2", Name = "hvl2", ProjectId = 2, Title = "title 12" },
                new Ticket { TicketId = 3, Description = "describe3", Name = "hvl3", ProjectId = 1, Title = "title 13" }

                );

        }
    }
}
