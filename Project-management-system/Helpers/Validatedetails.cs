using Project_management_system.Models;

namespace Project_management_system.Helpers
{
    public class Validatedetails
    {
        //validating user input 
        public static bool userDetails(string name, string password, string confirm)
        {
            bool IsValid;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirm))
            {
                IsValid = false;
                Console.WriteLine("All fields are required");
            }
            else if (password != confirm)
            {
                IsValid = false;
                Console.WriteLine("Passwords do not Match");
            }
            else
            {
                IsValid = true;
            }


            return IsValid;
        }

        //Checks if user is Admin 
        public  static bool  IsUserAdmin(User user)
        {
            bool isAdmin;
            if ((int)user.Role == 1)
            {
                isAdmin = true;
            }
            else
            {
                isAdmin = false;
            }


            return isAdmin;
        }
    }
}
