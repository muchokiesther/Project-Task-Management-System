using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_management_system.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;

        public ICollection<ProjectTasks> projectTasks = new List<ProjectTasks>();
       

        

    }
}
