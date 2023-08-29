using Microsoft.EntityFrameworkCore;
using project_management.Data;
using Project_management_system.Contoller;
using Project_management_system.Helpers;
using Project_management_system.Models;
using Project_management_system.Services;

namespace Project_management_system.Controller
{
    public class UserController
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        UserServices userServices = new UserServices();

        public static async Task Initialize()
        {
            await Console.Out.WriteLineAsync("\t\t\tProject Management System\n\n");
            await Console.Out.WriteLineAsync("Select options to continue\n 1.Login\n2.Register");
            var input = Console.ReadLine();
            bool Option = int.TryParse(input, out int Input);
            if (Option && Input == 1)
            {
                await Console.Out.WriteLineAsync("Username:");
                var username = Console.ReadLine();
                await Console.Out.WriteLineAsync("Password");
                var password = Console.ReadLine();
                await new UserController().Login(username, password);

            }
            else if (Option && Input == 2)
            {
                await Console.Out.WriteLineAsync("Username:");
                var username = Console.ReadLine();
                await Console.Out.WriteLineAsync("Password");
                var password = Console.ReadLine();
                await Console.Out.WriteLineAsync("Confirm password");
                var confirmpwd = Console.ReadLine();
                await new UserController().RegisterUser(username, password, confirmpwd);
            }
            else
            {
                await Console.Out.WriteLineAsync("Invalid input!!");
                await Initialize();
            }


        }
        public async Task RegisterUser(string username, string password, string confirmpwd)
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
                        Role = Roles.Admin,
                    };
                    await userServices.RegisterUserAsync(newUser);

                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);
                    await Initialize();
                }
            }

        }

        public async Task GetAllUserTasks(int userId)
        {
            var userTasks = await _context.Tasks.Where(u => u.userId == userId).ToListAsync();
            foreach(var userTask in userTasks)
            {
                await Console.Out.WriteLineAsync($"{userTask.TaskId}. {userTask.TaskName} status:{userTask.Status}");
            }

        }

        public async Task DeleteUser()
        {
            await DisplayAllUsers();
            await Console.Out.WriteLineAsync("Enter User Id To delete User");
            var Id = Console.ReadLine();
            int userId = Convert.ToInt32(Id);
            var userToDelete = await userServices.GetUserById(userId);


            if (userToDelete != null)
            {
                await userServices.UnregisterUserAsync(userToDelete);

            }
            else
            {
                await Console.Out.WriteLineAsync("User was not found");
                await DeleteUser();
            }

        }

        public async Task DisplayAllUsers()
        {
            List<User> AllUsers = await userServices.GetAllUsers();
            if (AllUsers != null)
            {
                foreach (var user in AllUsers)
                {
                    await Console.Out.WriteLineAsync($"{user.Id}. username:{user.username} Role:{user.Role}");
                }
            }
        }

        public async Task Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.username == username && u.password == password);
            if (user != null)
            {
                bool IsAdmin = Validatedetails.IsUserAdmin(user);
                if (IsAdmin)
                {
                    Console.WriteLine($"Welcome {user.Role}  {user.username}");
                    await AdminController.AdminPanel();
                }
                else
                {
                    await Console.Out.WriteLineAsync($"Welcome  {user.username}");
                    await UserPanel(user.Id);
                }

            }
            else
            {
                await Console.Out.WriteLineAsync("details did not match");
                await Initialize();
            }
        }
        public async static Task UserPanel(int id)
        {
            await Console.Out.WriteLineAsync("Select a Task to mark as Completed");
            await new UserController().GetAllUserTasks(id);
            await Console.Out.WriteLineAsync("Enter Task Id");
            var Id = Console.ReadLine();
            int TaskId = int.Parse(Id);
            await new AdminController().CompleteProject(TaskId);
            await new UserController().GetAllUserTasks(id);

        }


    }
}
