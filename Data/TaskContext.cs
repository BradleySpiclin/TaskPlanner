using Microsoft.EntityFrameworkCore;
using System;
using TaskPlanner.Models;

namespace TaskPlanner.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}
