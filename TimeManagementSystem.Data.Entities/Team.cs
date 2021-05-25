using System.Collections.Generic;

namespace TimeManagementSystem.Data.Entities
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public string ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
