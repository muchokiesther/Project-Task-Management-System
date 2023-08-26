using Project_management_system.Data;
using Project_management_system.Helpers;
using Project_management_system.Models;

namespace Project_management_system.Controller
{
    public class UserController
    {
       ApplicationDbContext _context = new ApplicationDbContext();
        public async Task RegisterUser(string username,string password,string confirmpwd)
        {
           //registering a user 
            bool validated = Validatedetails.userDetails(username, 
                password, confirmpwd); //validating the user inpuit
            if (validated)
            {
                try
                {
                    //creating a new user 
                    var newUser = new User()
                    {
                        username = username,
                        password = password,
                    };
                    await _context.AddAsync(newUser);
                    await _context.SaveChangesAsync();
                    await Console.Out.WriteLineAsync("User Registration successful");
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);
                }
            }
           
        }
    }
}
