using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using TimeManagementSystem.Data.Abstraction;
using TimeManagementSystem.Data.Entities;
using TimeManagementSystem.Data.Implementation.Repositories;

namespace TimeManagementSystem.Data.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationContext _applicationContext;

        public UnitOfWork(ApplicationContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _applicationContext = context;
            UserManager = userManager;
            SignInManager = signInManager;
        }
        IRepository<Project> _projectRepository;
        IRepository<TaskItem> _taskItemRepository;
        IRepository<Team> _teamRepository;
        IRepository<Report> _reportRepository;

        public IRepository<Project> ProjectRepository =>
            _projectRepository ??= new Repository<Project>(_applicationContext);

        public IRepository<Report> ReportRepository =>
            _reportRepository ??= new Repository<Report>(_applicationContext);

        public ITaskItemRepository TaskItemRepository => new TaskItemRepository(_applicationContext);

        public IRepository<Team> TeamRepository =>
            _teamRepository ??= new Repository<Team>(_applicationContext);

        public UserManager<User> UserManager { get; }

        public RoleManager<IdentityRole> RoleManager { get; }

        public SignInManager<User> SignInManager { get; }

        public async Task CommitAsync()
        {
            await _applicationContext.SaveChangesAsync();
        }
    }
}
