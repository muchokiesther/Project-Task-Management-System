using Microsoft.EntityFrameworkCore;
using project_management.Models;
using Project_management_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_management.Data
{
    public class ApplicationDbContext:DbContext
           
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectTasks> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = DESKTOP-Q8FU87I\\SQLEXPRESS; database = Project-Managements; TrustServerCertificate = true; Trusted_Connection = true; user Id  = sa; password = wamuyu@2023 ");//connecting to my database
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectTasks>()
                .HasOne(t => t.project)
                .WithMany(p => p.projectTasks)
                .HasForeignKey(t => t.ProjectId);
                
        }
    }
}
