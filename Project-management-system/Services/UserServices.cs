using Microsoft.EntityFrameworkCore;
using project_management.Data;
using Project_management_system.Models;
using Project_management_system.Services.IServices;

namespace Project_management_system.Services
{

    public class UserServices : IUserInterface
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public async Task<List<User>> GetAllUsers()
        {
            List<User> AllUsers = await _context.Users.ToListAsync();
            if (AllUsers == null)
            {
                await Console.Out.WriteLineAsync("Users not found");
            }
            return AllUsers;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                await Console.Out.WriteLineAsync("User does not exist");
            }

            return user;
        }

        public async Task RegisterUserAsync(User newUser)
        {
            try
            {
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                await Console.Out.WriteLineAsync("User Registration successful");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }

        }

        public async Task UnregisterUserAsync(User userToDelete)
        {
            try
            {
                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync();
                await Console.Out.WriteLineAsync("User Deleted Successfully");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }

        }
    }
}
