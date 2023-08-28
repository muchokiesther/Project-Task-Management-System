using Project_management_system.Models;

namespace Project_management_system.Services.IServices
{
    public interface IUserInterface
    {
        //Add user
        public Task RegisterUserAsync(User newUser);
        //Delete User
        public Task UnregisterUserAsync(User userToDelete);
        //get user by Id
        public Task<User> GetUserById(int id);
        //get all users
        public Task<List<User>> GetAllUsers();
    }
}
