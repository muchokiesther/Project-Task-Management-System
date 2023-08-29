using Project_management_system.Models;

namespace Project_management_system.Services.IServices
{
    public interface ITasksInterface
    {
        Task<SuccessMessage> AddTaskAsync(ProjectTasks tasks);
      

        Task<SuccessMessage> MarkTaskAsCompleted(ProjectTasks project, int Id);


    }
}
