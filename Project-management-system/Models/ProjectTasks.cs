using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_management.Models
{
    public class ProjectTasks
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; } = string.Empty;
       
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project project { get; set; }

    }
}
