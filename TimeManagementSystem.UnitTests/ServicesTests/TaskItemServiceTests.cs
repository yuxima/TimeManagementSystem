using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using TimeManagementSystem.BL.Abstraction;
using TimeManagementSystem.BL.DTO;
using TimeManagementSystem.BL.Implementation.Services;
using TimeManagementSystem.Data.Abstraction;
using TimeManagementSystem.Data.Implementation;

namespace TimeManagementSystem.UnitTests.ServicesTests
{
    [TestFixture]
    public class TaskItemServiceTests
    {
        private ITaskItemService _taskItemService;
        private ApplicationContext _context;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _context = new ApplicationContext(UnitTestsHelper.GetUnitTestDbOptions());
            _unitOfWork = new UnitOfWork(_context, null, null);
            _mapper = UnitTestsHelper.CreateMapperProfile();
            _taskItemService = new TaskItemService(_unitOfWork, _mapper);
        }

        [Test]
        public async Task GetAll_ReturnsAllEntities()
        {
            // Arrange
            var expectedCount = await _context.TaskItems.CountAsync();

            // Act
            var resultCount = _taskItemService.GetAllAsync();

            // Assert

            resultCount.Result.Count().Should().Be(expectedCount);
        }

        [Test]
        public async Task GetById_EntityExists_ReturnsEntity()
        {
            // Arrange
            var expected = await _context.TaskItems.FirstOrDefaultAsync(s => s.Id == "1");

            // Act
            var result = await _taskItemService.GetByIdAsync("1");

            // Assert
            result.Should().BeOfType<TaskItemDto>();
            result.Should().BeEquivalentTo(_mapper.Map<TaskItemDto>(expected));
        }

        [Test]
        public async Task GetById_EntityNotExists_ReturnsNull()
        {
            // Act
            var result = await _taskItemService.GetByIdAsync("10");

            // Assert
            result.Should().BeNull();
        }

        [Test]
        public async Task AddAsync_AddEntity()
        {
            // Arrange
            var expectedCount = await _context.TaskItems.CountAsync();

            // Act
            await _taskItemService.AddAsync(new TaskItemDto() { Id = "3", Name = "1" });
            var resultCount = await _context.TaskItems.CountAsync();

            // Assert
            resultCount.Should().Be(expectedCount + 1);
        }

        [Test]
        public async Task DeleteAsync_DeletesEntity()
        {
            // Arrange
            var expectedCount = await _context.TaskItems.CountAsync();

            // Act
            await _taskItemService.DeleteByIdAsync("1");
            var resultCount = await _context.TaskItems.CountAsync();

            // Assert
            resultCount.Should().Be(expectedCount - 1);
        }

        [Test]
        public async Task UpdateAsync_UpdatesEntity()
        {
            // Arrange
            var expected = await _context.TaskItems.AsNoTracking().FirstOrDefaultAsync(s => s.Id == "1");

            // Act
            await _taskItemService.UpdateAsync(new TaskItemDto() { Id = "1", Name = "2" });
            var result = await _context.TaskItems.AsNoTracking().FirstOrDefaultAsync(s => s.Id == "1");
            // Assert
            expected.Id.Should().Be(result.Id);
            expected.Name.Should().NotBe(result.Name);
        }
    }
}
