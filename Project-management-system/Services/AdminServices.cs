using Microsoft.EntityFrameworkCore;
using project_management.Data;
using Project_management_system.Models;
using Project_management_system.Services.IServices;

namespace project_management.Services
{
    public class AdminServices : IProjectInterface, ITasksInterface
    {
        ApplicationDbContext _context = new ApplicationDbContext();


        public async Task<SuccessMessage> DeleteProjectAsync(int ProjectId)
        {
            try
            {
                var projectToDelete = await _context.Projects.FirstAsync(x => x.ProjectId == ProjectId);
                _context.Projects.Remove(projectToDelete);
                await _context.SaveChangesAsync();
                return new SuccessMessage { Message = "project deleted" };
            }
            catch (Exception ex)
            {
                return new SuccessMessage { Message = ex.Message };

            }
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            var projects = await _context.Projects.ToListAsync();
            if (projects == null)
            {
                await Console.Out.WriteLineAsync("projects not found");
            }

            return projects;
        }

        public async Task<List<ProjectTasks>> GetAllTasksAsync()
        {


            throw new NotImplementedException();
        }

        public async Task<SuccessMessage> UpdateProjectAsync(Project updatedProject, int id)
        {
            try
            {
                var projectToUpdate = _context.Projects.First(x => x.ProjectId == id);
                projectToUpdate.ProjectName = updatedProject.ProjectName;
                await _context.SaveChangesAsync();
                return new SuccessMessage { Message = "Project Updated Successfully" };
            }
            catch (Exception ex)
            {
                return new SuccessMessage { Message = ex.Message };
            }

        }

        public async Task<SuccessMessage> AddProjectAsync(Project newProject)
        {
            try
            {
                await _context.Projects.AddAsync(newProject);
                await _context.SaveChangesAsync();
                return new SuccessMessage { Message = "Project created successfully" };
            }
            catch (Exception ex)
            {
                return new SuccessMessage { Message = ex.Message };
            }

        }

        public async Task<SuccessMessage> AddTaskAsync(ProjectTasks tasks)
        {
            try
            {
                await _context.AddAsync(tasks);
                await _context.SaveChangesAsync();
                return new SuccessMessage { Message = "Task Added successfully" };
            }
            catch (Exception ex)
            {
                return new SuccessMessage { Message = ex.Message };
            }

        }
    }
}
