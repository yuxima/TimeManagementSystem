using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManagementSystem.Data.Entities
{
    public class TaskItem:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Project Project { get; set; }
        public string ProjectId { get; set; }
        public Report Report { get; set; }
    }
}
