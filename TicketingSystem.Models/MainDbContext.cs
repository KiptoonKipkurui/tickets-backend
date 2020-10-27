using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketingSystem.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Event>(options =>
            {
                options.Property(x => x.Id).ValueGeneratedOnAdd();
                options.HasIndex(x => x.UserId);
                options.HasIndex(x => x.Date);
            });

            builder.Entity<Ticket>(options =>
            {
                options.Property(x => x.Id).ValueGeneratedOnAdd(); 
                options.HasIndex(x => x.UserId);
                options.HasIndex(x => x.EventId);
            });

            builder.Entity<User>(options =>
            {
                options.Property(x => x.Id).ValueGeneratedOnAdd();

            });
        }
    }
}
