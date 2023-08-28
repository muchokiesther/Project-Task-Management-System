
using project_management.Contoller;
using Project_management_system.Controller;

class Program
{


  

       static async Task Main(string[] args)
        {
            var adminController = new AdminController();
            await adminController.Init();

            await UserController.Initialize();
        }
    }


