using Microsoft.EntityFrameworkCore;
using project_management.Data;
using project_management.Models;
using project_management.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace project_management.Contoller
{
    public class AdminController
    {
        AdminServices services = new AdminServices();
        ApplicationDbContext _context = new ApplicationDbContext();

        public async Task Init()
        {
            Console.WriteLine("Admin Menu:");
            Console.WriteLine("1. Create Project");
            Console.WriteLine("2. Update Project");
            Console.WriteLine("3. View All Projects");
            Console.WriteLine("4. Add Task for Project");
            Console.WriteLine("5. Delete Project");
            Console.WriteLine("6. Exit");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await CreateProject();
                    break;
                case "2":
                    await UpdateProject();
                    break;
                case "3":
                    await GetAllProjects();
                    break;
                case "4":
                    await CreateNewTask();
                    break;
                case "5":
                    await DeleteProject();
                    break;

                case "6":
                    Console.WriteLine("Exiting Admin Menu...");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    await Init();
                    break;
            }

            await Init();
        }

        public async Task CreateProject()
        {
            Console.WriteLine("Enter Project Name:");
            var projectName = Console.ReadLine();

            // Create a new project
            var newProject = new Project()
            {
                ProjectName = projectName,
            };

            await services.AddProjectAsync(newProject);
            Console.WriteLine("Project created successfully!");
        }

        public async Task UpdateProject()
        {
            await GetAllProjects();
            Console.WriteLine("Enter Project Id:");
            var pid = Console.ReadLine();
            int projectId = int.Parse(pid);

            Console.WriteLine("Enter New Project Name:");
            var newName = Console.ReadLine();

            // Create an updated project instance
            var updatedP = new Project()
            {
                ProjectName = newName
            };

            await services.UpdateProjectAsync(updatedP, projectId);
            Console.WriteLine("Project updated successfully!");
        }

        public async Task GetAllProjects()
        {
            var projects = await services.GetAllProjectsAsync();
            foreach (var project in projects)
            {
                Console.WriteLine($"{project.ProjectId}. {project.ProjectName}");
                foreach (var task in project.projectTasks)
                {
                    Console.WriteLine($"{task.ProjectId}. {task.TaskName}");
                }
            }
        }

        public async Task CreateNewTask()
        {
            await GetAllProjects();
            Console.WriteLine("Enter Project Id:");
            var pid = Console.ReadLine();
            int projectId = int.Parse(pid);

            Console.WriteLine("Enter Task Name:");
            var taskName = Console.ReadLine();

            // Find the project to add the task to
            var projectToAddTask = _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == projectId);

            if (projectToAddTask != null)
            {
                var newTask = new ProjectTasks()
                {
                    TaskName = taskName,
                    ProjectId = projectId
                };
                await services.AddTaskAsync(newTask);
                Console.WriteLine("Task added successfully!");
            }
            else
            {
                Console.WriteLine("Project not found.");
            }
        }

        public async Task DeleteProject()
        {
            await GetAllProjects();
            Console.WriteLine("Enter Project ID:");
            var pid = Console.ReadLine();
            int projectId = int.Parse(pid);

            await services.DeleteProjectAsync(projectId);
            Console.WriteLine("Project deleted successfully!");
        }

    }
}
