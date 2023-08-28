
using Project_management_system.Controller;

class Program
{
    
    static async Task Main(string[] args)
    {
       
        await UserController.Initialize();
    }
}
