using Microsoft.EntityFrameworkCore;
using project_management.Data;
using project_management.Models;
using project_management.Services;

namespace project_management.Contoller
{
    public class AdminController
    {
        AdminServices services = new AdminServices();
        ApplicationDbContext _context = new ApplicationDbContext();
        public async Task CreateProject(string projectname)
        {
            var newProject = new Project()
            {
                ProjectName = projectname,
            };
            await services.AddProjectAsync(newProject);
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
                foreach(var task in project.projectTasks)
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
            var projectToAddTask =  _context.Projects.FirstOrDefaultAsync(x=> x.ProjectId == ProjectId);
            if(projectToAddTask != null)
            {
                var newTask = new ProjectTasks()
                {
                    TaskName=name,
                    ProjectId=ProjectId 
                };
                await services.AddTaskAsync(newTask);
            }


        }
        //delete project

        public async Task DeleteProject()
        {
            await GetAllProjects();
            Console.WriteLine("Type in project ID");
            var pid = Console.ReadLine();
            int ProjectId = int.Parse(pid);
            await services.DeleteProjectAsync(ProjectId);

        }
        

    }
}
