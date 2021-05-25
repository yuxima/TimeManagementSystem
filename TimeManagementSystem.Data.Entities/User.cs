using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TimeManagementSystem.Data.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string TeamId { get; set; }
        public Team Team { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}
