using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TimeManagementSystem.Data.Entities;

namespace TimeManagementSystem.Data.Abstraction
{
    public interface IUnitOfWork
    {
        IRepository<Project> ProjectRepository { get; }
        IRepository<Report> ReportRepository { get; }
        ITaskItemRepository TaskItemRepository { get; }
        IRepository<Team> TeamRepository { get; }
        UserManager<User> UserManager { get; }
        RoleManager<IdentityRole> RoleManager { get; }
        SignInManager<User> SignInManager { get; }

        Task CommitAsync();
    }
}
