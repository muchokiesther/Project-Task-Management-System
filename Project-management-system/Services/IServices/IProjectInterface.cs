using Project_management_system.Models;

namespace Project_management_system.Services.IServices
{
    internal interface IProjectInterface
    {

        Task<SuccessMessage> UpdateProjectAsync(Project updatedProject, int Id);
        Task<SuccessMessage> DeleteProjectAsync(int ProjectId);
        Task<List<Project>> GetAllProjectsAsync();
        Task<SuccessMessage> AddProjectAsync(Project newProject);


    }
}
