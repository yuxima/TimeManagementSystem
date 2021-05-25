using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeManagementSystem.Data.Entities;

namespace TimeManagementSystem.Data.Implementation
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            base.Database.EnsureCreated();
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            { Name = "developer", NormalizedName = "developer".ToUpper() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            { Name = "projectManager", NormalizedName = "projectManager".ToUpper() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            { Name = "techLead", NormalizedName = "techLead".ToUpper() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            { Name = "teamMember", NormalizedName = "teamMember".ToUpper() });
        }
    }
}
