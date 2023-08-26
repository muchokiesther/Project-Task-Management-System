
using Project_management_system.Controller;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        UserController userController = new UserController();

        Console.WriteLine("Enter user details");
        Console.WriteLine("username");
        var username = Console.ReadLine();
        Console.WriteLine("Password");
        var password = Console.ReadLine();
        Console.WriteLine("Comfirm password");
        var pwd = Console.ReadLine();
       await userController.RegisterUser(username, password, pwd);
    }
}
