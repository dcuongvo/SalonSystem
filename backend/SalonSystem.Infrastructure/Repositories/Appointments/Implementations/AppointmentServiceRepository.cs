using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Appointments;
using SalonSystem.Infrastructure.Data;
using SalonSystem.Infrastructure.Repositories.Appointments.Interfaces;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;

namespace SalonSystem.Infrastructure.Repositories.Appointments.Implementations
{
    public class AppointmentServiceRepository : GenericRepository<AppointmentService>, IAppointmentServiceRepository
    {
        public AppointmentServiceRepository(SalonSystemDbContext context) : base(context) { }
    }
}
