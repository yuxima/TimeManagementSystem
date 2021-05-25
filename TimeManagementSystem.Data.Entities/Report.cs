using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManagementSystem.Data.Entities
{
    public class Report: BaseEntity
    {
        public string Name { get; set; }
        public string TaskItemId { get; set; }
        [ForeignKey("TaskItemId")]
        public TaskItem TaskItem { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
