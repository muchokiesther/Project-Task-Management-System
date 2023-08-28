using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_management_system.Models
{
    public class ProjectTasks
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; } = string.Empty;

        public int ProjectId { get; set; }

        public Project project { get; set; }

        public int userId { get; set; }

        public User User { get; set; }

       

    }
}
