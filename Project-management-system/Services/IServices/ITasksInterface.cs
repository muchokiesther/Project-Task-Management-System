using project_management.Models;

namespace Project_management_system.Services.IServices
{
    public interface ITasksInterface
    {
        Task<SuccessMessage> AddTaskAsync(ProjectTasks tasks);
        Task<List<ProjectTasks>> GetAllTasksAsync();


    }
}
