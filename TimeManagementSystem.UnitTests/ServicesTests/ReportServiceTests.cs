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
    public class ReportServiceTests
    {
        private IReportService _reportService;
        private ApplicationContext _context;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _context = new ApplicationContext(UnitTestsHelper.GetUnitTestDbOptions());
            _unitOfWork = new UnitOfWork(_context, null, null);
            _mapper = UnitTestsHelper.CreateMapperProfile();
            _reportService = new ReportService(_unitOfWork, _mapper);
        }

        [Test]
        public async Task GetAll_ReturnsAllEntities()
        {
            // Arrange
            var expectedCount = await _context.Reports.CountAsync();

            // Act
            var resultCount = _reportService.GetAllAsync();

            // Assert

            resultCount.Result.Count().Should().Be(expectedCount);
        }

        [Test]
        public async Task GetById_EntityExists_ReturnsEntity()
        {
            // Arrange
            var expected = await _context.Reports.FirstOrDefaultAsync(s => s.Id == "1");

            // Act
            var result = await _reportService.GetByIdAsync("1");

            // Assert
            result.Should().BeOfType<ReportDto>();
            result.Should().BeEquivalentTo(_mapper.Map<ReportDto>(expected));
        }

        [Test]
        public async Task GetById_EntityNotExists_ReturnsNull()
        {
            // Act
            var result = await _reportService.GetByIdAsync("10");

            // Assert
            result.Should().BeNull();
        }

        [Test]
        public async Task AddAsync_AddEntity()
        {
            // Arrange
            var expectedCount = await _context.Reports.CountAsync();

            // Act
            await _reportService.AddAsync(new ReportDto { Id = "3", Name = "1" });
            var resultCount = await _context.Reports.CountAsync();

            // Assert
            resultCount.Should().Be(expectedCount + 1);
        }

        [Test]
        public async Task DeleteAsync_DeletesEntity()
        {
            // Arrange
            var expectedCount = await _context.Reports.CountAsync();

            // Act
            await _reportService.DeleteByIdAsync("1");
            var resultCount = await _context.Reports.CountAsync();

            // Assert
            resultCount.Should().Be(expectedCount - 1);
        }

        [Test]
        public async Task UpdateAsync_UpdatesEntity()
        {
            // Arrange
            var expected = await _context.Reports.AsNoTracking().FirstOrDefaultAsync(s => s.Id == "1");

            // Act
            await _reportService.UpdateAsync(new ReportDto { Id = "1", Name = "2" });
            var result = await _context.Reports.AsNoTracking().FirstOrDefaultAsync(s => s.Id == "1");
            // Assert
            expected.Id.Should().Be(result.Id);
            expected.Name.Should().NotBe(result.Name);
        }
    }
}
