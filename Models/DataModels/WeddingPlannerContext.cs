using System;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Models
{
    public class WeddingPlannerContext: DbContext
    {
        public WeddingPlannerContext(DbContextOptions options): base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Wedding> Wedding { get; set; }
        public DbSet<Guest> Guest { get; set; }
    }
}