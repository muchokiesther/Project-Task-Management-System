using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_management_system.Helpers
{
    public class Validatedetails
    {
        //validating user input 
        public static bool  userDetails(string name, string password, string confirm)
        {
            bool IsValid = false;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirm))
            {
                IsValid = false;
                Console.WriteLine("All fields are required");
            }
            else if(password != confirm)
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
    }
}
