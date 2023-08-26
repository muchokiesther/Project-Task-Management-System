using Microsoft.EntityFrameworkCore;
using Project_management_system.Models;

namespace Project_management_system.Data
{
    public class ApplicationDbContext:DbContext
    {
        DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-VF9PAJV;Initial Catalog=Project-Management-System;User ID=karani-ken;Password=***********;Trust Server Certificate=True;Integrated Security=True;");
        }
       // protected override void OnModelCreating(ModelBuilder modelBuilder)
       // {
            
     //   }

    }
}
