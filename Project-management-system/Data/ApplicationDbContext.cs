using Microsoft.EntityFrameworkCore;

using Project_management_system.Models;


namespace project_management.Data
{
    public class ApplicationDbContext : DbContext

    {
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectTasks> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(" Data Source=DESKTOP-VF9PAJV;Initial Catalog=Project-Management-Systems;User ID=karani-ken;Password=***********;Trust Server Certificate=True;Integrated Security=True;");//connecting to my database
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasMany(p => p.projectTasks)
                .WithOne(t => t.project)
                .HasForeignKey(t => t.ProjectId);
            modelBuilder.Entity<ProjectTasks>()
                .HasOne(t => t.User)
                .WithMany(u => u.Assignedtasks)
                .HasForeignKey(t => t.userId);
                

              
        }
    }
}
