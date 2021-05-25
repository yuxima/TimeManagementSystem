using System.Collections.Generic;

namespace TimeManagementSystem.Data.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Abbr { get; set; }
        public ICollection<Team> Teams { get; set; }
        public ICollection<TaskItem> TaskItems { get; set; }
    }
}
