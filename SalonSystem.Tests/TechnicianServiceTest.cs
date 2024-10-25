using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Import for In-Memory DB
using Moq;
using Xunit;
using SalonSystem.Models.Salons;
using SalonSystem.Models.Technicians;
using SalonSystem.Services;
using SalonSystem.Data.Repositories;
using SalonSystem.DTOs;
using SalonSystem.Data;
using System;

namespace SalonSystem.Tests
{
    public class TechnicianServiceTests
    {
        private readonly Mock<ITechnicianRepository> _mockTechnicianRepository;
        private readonly TechnicianService _technicianService;
        private readonly SalonSystemDbContext _dbContext;

        public TechnicianServiceTests()
        {
            // Use an in-memory database
            var options = new DbContextOptionsBuilder<SalonSystemDbContext>()
                .UseInMemoryDatabase(databaseName: "SalonSystemTestDb") // In-Memory DB Setup
                .Options;

            _dbContext = new SalonSystemDbContext(options);
            _mockTechnicianRepository = new Mock<ITechnicianRepository>();

            _technicianService = new TechnicianService(_mockTechnicianRepository.Object, _dbContext);
        }
        //Test Create Technician------------------------------------------------------------- 
        [Fact]
        public async Task AddTechnicianAsync_Successfully()
        {
            var createSalonDto = new Salon { Name = "Test Salon" };

            _dbContext.Salons.Add(createSalonDto);
            await _dbContext.SaveChangesAsync();

            var createTechnicianDto = new CreateTechnicianDto
            {
                Name = "John Doe",
                Salary = 5000,
                SalonId = createSalonDto.SalonId
            };

            var technician = new Technician
            {
                TechnicianId = 1,
                Name = createTechnicianDto.Name,
                Salary = createTechnicianDto.Salary,
                SalonId = createTechnicianDto.SalonId
            };

            // Set up the technician repository
            _mockTechnicianRepository.Setup(repo => repo.AddTechnicianAsync(It.IsAny<Technician>()))
                .ReturnsAsync(technician);

            // Act: 
            var result = await _technicianService.AddTechnicianAsync(createTechnicianDto);

            // Assert:
            Assert.NotNull(result);
            Assert.Equal(createTechnicianDto.Name, result.Name);
            Assert.Equal(createTechnicianDto.Salary, result.Salary);
            Assert.Equal(createTechnicianDto.SalonId, result.SalonId);
        }

        [Fact]
        public async Task AddTechnicianAsync_Null()
        {
            // Arrange: Create a Salon and add it to the in-memory database
            var createSalonDto = new Salon { Name = "Test Salon" };
            _dbContext.Salons.Add(createSalonDto);
            await _dbContext.SaveChangesAsync();

            // Arrange: Prepare Technician data to be added
            var createTechnicianDto = new CreateTechnicianDto
            {
                Name = "Invalid Technician",
                Salary = 4000,
                SalonId = createSalonDto.SalonId
            };

            _mockTechnicianRepository.Setup(repo => repo.AddTechnicianAsync(It.IsAny<Technician>()))
                .ThrowsAsync(new InvalidOperationException("Failed to add technician."));

            // Act & Assert: exception
            await Assert.ThrowsAsync<InvalidOperationException>(() => _technicianService.AddTechnicianAsync(createTechnicianDto));
        }

        [Fact]
        public async Task AddTechnicianAsync_CannotFoundSalon()
        {
            // Arrange: 
            var createTechnicianDto = new CreateTechnicianDto
            {
                Name = "John Doe",
                Salary = 5000,
                SalonId = 999 
            };
            // Act & Assert:
            await Assert.ThrowsAsync<InvalidOperationException>(() => _technicianService.AddTechnicianAsync(createTechnicianDto));
        }
 
        //Update ------------------------------------------------------
        [Fact]
        public async Task UpdateTechnicianAsync_Sucess()
        {
            // Arrange
            var technicianId = 1;
            var existingTechnician = new Technician { TechnicianId = technicianId, Name = "John Doe", Salary = 5000 };
            var updatedTechnician = new Technician { TechnicianId = technicianId, Name = "Jane Doe", Salary = 6000 };

            _mockTechnicianRepository.Setup(repo => repo.GetTechnicianByIdAsync(technicianId))
                .ReturnsAsync(existingTechnician);
            _mockTechnicianRepository.Setup(repo => repo.UpdateTechnicianAsync(It.IsAny<Technician>()))
                .ReturnsAsync(updatedTechnician);

            // Act
            var result = await _technicianService.UpdateTechnicianAsync(technicianId, updatedTechnician);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Jane Doe", result.Name);
            Assert.Equal(6000, result.Salary);
        }

        [Fact]
        public async Task UpdateTechnicianAsync_NotFound()
        {
            // Arrange
            var technicianId = 999;
            var updatedTechnician = new Technician { TechnicianId = technicianId, Name = "Jane Doe", Salary = 6000 };

            _mockTechnicianRepository.Setup(repo => repo.GetTechnicianByIdAsync(technicianId))
                .ReturnsAsync((Technician)null);

            // Act
            var result = await _technicianService.UpdateTechnicianAsync(technicianId, updatedTechnician);

            // Assert
            Assert.Null(result);
        }

        //Delete-------------------------------------------------------
        [Fact]
        public async Task DeleteTechnicianAsync_Success()
        {
            // Arrange
            var technicianId = 1;

            _mockTechnicianRepository.Setup(repo => repo.DeleteTechnicianAsync(technicianId))
                .ReturnsAsync(true);

            // Act
            var result = await _technicianService.DeleteTechnicianAsync(technicianId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteTechnicianAsync_NoExist()
        {
            // Arrange
            var technicianId = 999;

            _mockTechnicianRepository.Setup(repo => repo.DeleteTechnicianAsync(technicianId))
                .ReturnsAsync(false);

            // Act
            var result = await _technicianService.DeleteTechnicianAsync(technicianId);

            // Assert
            Assert.False(result);
        }
    }
}
