using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_management.Models
{
   public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
              
        public ICollection<ProjectTasks> projectTasks = new List<ProjectTasks>();
       
    }
}
