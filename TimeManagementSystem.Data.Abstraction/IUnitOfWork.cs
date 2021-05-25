using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TimeManagementSystem.Data.Entities;

namespace TimeManagementSystem.Data.Abstraction
{
    public interface IUnitOfWork
    {
        IRepository<Project> ProjectRepository { get; }
        IRepository<Report> ReportRepository { get; }
        IRepository<TaskItem> TaskItemRepository { get; }
        IRepository<Team> TeamRepository { get; }
        UserManager<User> UserManager { get; }
        RoleManager<IdentityRole> RoleManager { get; }
        SignInManager<User> SignInManager { get; }

        Task CommitAsync();
    }
}
