using Microsoft.EntityFrameworkCore;
using project_management.Data;
using project_management.Services;
using Project_management_system.Controller;
using Project_management_system.Models;
using Project_management_system.Services;

namespace Project_management_system.Contoller
{
    public class AdminController
    {
        AdminServices services = new AdminServices();
        ApplicationDbContext _context = new ApplicationDbContext();
        public async static Task AdminPanel()
        {
            await Console.Out.WriteLineAsync("Select An Option: \n 1.View Projects\n 2.Create Project\n 3.Update Project\n 4." +
                "Delete Project\n 5. Delete User\n 6. Create new Tasks");
            var option = Console.ReadLine();
            bool convertedOption = int.TryParse(option, out int Option);
            if (convertedOption)
            {
                await new AdminController().SwitchMenu(Option);
            }
            else
            {
                await AdminPanel();
            }
        }
        public async Task SwitchMenu(int option)
        {
            switch(option)
            {
                case 1:
                    await new AdminController().GetAllProjects();
                    break;
                case 2:
                    await new AdminController().CreateProject();
                    break;
                case 3:
                    await new AdminController().UpdateProject();
                    break;
                case 4:
                    await new AdminController().DeleteProject();
                    break;
                case 5:
                    await new UserController().DeleteUser();
                    break;
                case 6:
                    await new AdminController().CreateNewTask();
                    break;
                default:
                    await AdminPanel();
                    break;
            }
        }
        public async Task CreateProject()
        {
            await Console.Out.WriteLineAsync("Project name:");
            var projectname = Console.ReadLine();
            var newProject = new Project()
            {
                ProjectName = projectname,
            };
          var response =  await services.AddProjectAsync(newProject);
             Console.WriteLine(response.Message);
        }
        //update project
        public async Task UpdateProject()
        {
            await GetAllProjects();
            await Console.Out.WriteLineAsync("Project Id:");
            var pid = Console.ReadLine();
            int projectId = int.Parse(pid);
            await Console.Out.WriteLineAsync("Project name:");
            var name = Console.ReadLine();
            var updatedP = new Project()
            {
                ProjectName = name

            };

            await services.UpdateProjectAsync(updatedP, projectId);

        }
        //get all projects
        public async Task GetAllProjects()
        {
            var projects = await services.GetAllProjectsAsync();
            foreach (var project in projects)
            {
                Console.WriteLine($"{project.ProjectId}. {project.ProjectName}");
                foreach (var task in project.projectTasks)
                {
                    await Console.Out.WriteLineAsync($"{task.ProjectId} . {task.TaskName}");
                }
            }
        }
        //Add a task for a certain project
        public async Task CreateNewTask()
        {           
            await GetAllProjects();           
            await Console.Out.WriteLineAsync("Project Id:");
            var pid = Console.ReadLine();
            int ProjectId = int.Parse(pid);
            await Console.Out.WriteLineAsync("Task name:");
            var name = Console.ReadLine();
            await Console.Out.WriteLineAsync("Select User To Assign Task:");
            await GetUsersWithouTasks();
            await Console.Out.WriteLineAsync("Enter user Id To select");
            var Uid = Console.ReadLine();
            int UserId = int.Parse(Uid);
            var projectToAddTask = _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == ProjectId);
            if (projectToAddTask != null)
            {
                var newTask = new ProjectTasks()
                {
                    TaskName = name,
                    ProjectId = ProjectId,
                    userId=UserId,
                };
                await services.AddTaskAsync(newTask);
            }


        }
        //delete project

        public async Task DeleteProject()
        {
            await GetAllProjects();
            Console.WriteLine("Type in project ID to Delete project");
            var pid = Console.ReadLine();
            int ProjectId = int.Parse(pid);
            await services.DeleteProjectAsync(ProjectId);

        }
        //get all users withous Tasks
        public async Task GetUsersWithouTasks()
        {
            var usersWithoutTasks = await _context.Users.Where(u => u.Assignedtasks.Count == 0).ToListAsync();

            foreach(var user in usersWithoutTasks)
            {
                await Console.Out.WriteLineAsync($"{user.Id}. {user.username}");
            }

        }


    }
}
