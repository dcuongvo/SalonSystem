using Moq;
using SalonSystem.Data.Repositories;
using SalonSystem.Models.Technicians;
using SalonSystem.Models.Services;
using SalonSystem.Services;
using System.Threading.Tasks;

using Xunit;

namespace SalonSystem.Tests.UnitTests
{
    public class TechnicianServiceTests
    {
        private readonly TechnicianService _technicianService;
        private readonly Mock<ITechnicianRepository> _mockTechnicianRepository;

        public TechnicianServiceTests()
        {
            _mockTechnicianRepository = new Mock<ITechnicianRepository>();
            _technicianService = new TechnicianService(_mockTechnicianRepository.Object);
        }

        [Fact]
        public async Task AddTechnicianAsync_ShouldReturnNewTechnician()
        {
            // Arrange
            var newTechnician = new Technician
            {
                TechnicianId = 1,
                Name = "Technician A",
                Salary = 1450
            };
            _mockTechnicianRepository.Setup(repo => repo.AddTechnicianAsync(It.IsAny<Technician>())).ReturnsAsync(newTechnician);

            // Act
            var result = await _technicianService.AddTechnicianAsync(newTechnician);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newTechnician.TechnicianId, result.TechnicianId);
            Assert.Equal("Technician A", result.Name);
        }
    }
}
