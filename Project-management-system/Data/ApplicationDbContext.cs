using Microsoft.EntityFrameworkCore;

namespace Project_management_system.Data
{
    public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-VF9PAJV;Initial Catalog=Project-Management-System;User ID=karani-ken;Password=***********");
        }
       // protected override void OnModelCreating(ModelBuilder modelBuilder)
       // {
            
     //   }

    }
}
