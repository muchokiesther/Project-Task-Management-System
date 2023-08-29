using System.ComponentModel.DataAnnotations;

namespace Project_management_system.Models
{
    public enum Status
    {
        Complete = 1,
        NotYet = 2
    }
    public class ProjectTasks
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; } = string.Empty;

        public Status Status { get; set; } = Status.NotYet;
        public int ProjectId { get; set; }

        public Project project { get; set; }

        public int userId { get; set; }

        public User User { get; set; }





    }
}
