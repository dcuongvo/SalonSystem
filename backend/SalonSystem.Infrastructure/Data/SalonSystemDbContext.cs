using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Users;
using SalonSystem.Domain.Entities.Salons;
using SalonSystem.Domain.Entities.Technicians;
using SalonSystem.Domain.Entities.Services;
using SalonSystem.Domain.Entities.Appointments;
using SalonSystem.Domain.Entities.Employees;


namespace SalonSystem.Infrastructure.Data
{
    public class SalonSystemDbContext : DbContext
    {
        public SalonSystemDbContext(DbContextOptions<SalonSystemDbContext> options) : base(options) { }

        // DbSets for all entities
        public DbSet<User> Users { get; set; }
        public DbSet<SubUser> SubUsers { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<SalonSchedule> SalonSchedules { get; set; }
        public DbSet<DayClose> DayCloses { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<TechnicianSkill> TechnicianSkills { get; set; }
        public DbSet<TechnicianSchedule> TechnicianSchedules { get; set; }
        public DbSet<TimeBlock> TimeBlocks { get; set; }
        public DbSet<DayOff> DaysOff { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceSkill> ServiceSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentService> AppointmentServices { get; set; }
        public DbSet<AppointmentTechnician> AppointmentTechnicians { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Employee Configuration
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.EmployeeId);

            // Technician Configuration
            modelBuilder.Entity<Technician>()
                .HasBaseType<Employee>();
            // User Relationships
            modelBuilder.Entity<User>()
                .HasMany(user => user.Salons)
                .WithOne(salon => salon.Owner)
                .HasForeignKey(salon => salon.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(user => user.SubUsers)
                .WithOne(subUser => subUser.Owner)
                .HasForeignKey(subUser => subUser.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Salon Relationships
            modelBuilder.Entity<Salon>()
                .HasMany(salon => salon.Technicians)
                .WithOne(technician => technician.AssociatedSalon)
                .HasForeignKey(technician => technician.SalonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Salon>()
                .HasMany(salon => salon.Services)
                .WithOne(service => service.AssociatedSalon)
                .HasForeignKey(service => service.SalonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Salon>()
                .HasMany(salon => salon.Skills)
                .WithOne(skill => skill.AssociatedSalon)
                .HasForeignKey(skill => skill.SalonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Salon>()
                .HasMany(salon => salon.DayCloses)
                .WithOne(dayClose => dayClose.Salon)
                .HasForeignKey(dayClose => dayClose.SalonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Technician Relationships
            modelBuilder.Entity<Technician>()
                .HasMany(technician => technician.TechnicianSkills)
                .WithOne(technicianSkill => technicianSkill.Technician)
                .HasForeignKey(technicianSkill => technicianSkill.TechnicianId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Technician>()
                .HasMany(technician => technician.TechnicianSchedules)
                .WithOne(technicianSchedule => technicianSchedule.Technician)
                .HasForeignKey(technicianSchedule => technicianSchedule.TechnicianId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Technician>()
                .HasMany(technician => technician.DaysOff)
                .WithOne(dayOff => dayOff.Technician)
                .HasForeignKey(dayOff => dayOff.TechnicianId)
                .OnDelete(DeleteBehavior.Cascade);

            // TechnicianSkill Many-to-Many Relationship
            modelBuilder.Entity<TechnicianSkill>()
                .HasKey(technicianSkill => new { technicianSkill.TechnicianId, technicianSkill.SkillId });

            modelBuilder.Entity<TechnicianSkill>()
                .HasOne(technicianSkill => technicianSkill.Skill)
                .WithMany(skill => skill.TechnicianSkills)
                .HasForeignKey(technicianSkill => technicianSkill.SkillId)
                .OnDelete(DeleteBehavior.Restrict);

            // Service Relationships
            modelBuilder.Entity<Service>()
                .HasMany(service => service.ServiceSkills)
                .WithOne(serviceSkill => serviceSkill.Service)
                .HasForeignKey(serviceSkill => serviceSkill.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // ServiceSkill Many-to-Many Relationship
            modelBuilder.Entity<ServiceSkill>()
                .HasKey(serviceSkill => new { serviceSkill.ServiceId, serviceSkill.SkillId });

            modelBuilder.Entity<ServiceSkill>()
                .HasOne(serviceSkill => serviceSkill.Skill)
                .WithMany(skill => skill.ServiceSkills)
                .HasForeignKey(serviceSkill => serviceSkill.SkillId)
                .OnDelete(DeleteBehavior.Restrict);

            // Appointment Relationships
            modelBuilder.Entity<Appointment>()
                .HasMany(appointment => appointment.AppointmentTechnicians)
                .WithOne(appointmentTechnician => appointmentTechnician.Appointment)
                .HasForeignKey(appointmentTechnician => appointmentTechnician.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .HasMany(appointment => appointment.AppointmentServices)
                .WithOne(appointmentService => appointmentService.Appointment)
                .HasForeignKey(appointmentService => appointmentService.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-Many: Appointment and Technician
            modelBuilder.Entity<AppointmentTechnician>()
                .HasKey(appointmentTechnician => new { appointmentTechnician.AppointmentId, appointmentTechnician.TechnicianId });

            modelBuilder.Entity<AppointmentTechnician>()
                .HasOne(appointmentTechnician => appointmentTechnician.Appointment)
                .WithMany(appointment => appointment.AppointmentTechnicians)
                .HasForeignKey(appointmentTechnician => appointmentTechnician.AppointmentId);

            modelBuilder.Entity<AppointmentTechnician>()
                .HasOne(appointmentTechnician => appointmentTechnician.Technician)
                .WithMany(technician => technician.AppointmentTechnicians)
                .HasForeignKey(appointmentTechnician => appointmentTechnician.TechnicianId);

            // Many-to-Many: Appointment and Service
            modelBuilder.Entity<AppointmentService>()
                .HasKey(appointmentService => new { appointmentService.AppointmentId, appointmentService.ServiceId });

            modelBuilder.Entity<AppointmentService>()
                .HasOne(appointmentService => appointmentService.Appointment)
                .WithMany(appointment => appointment.AppointmentServices)
                .HasForeignKey(appointmentService => appointmentService.AppointmentId);

            modelBuilder.Entity<AppointmentService>()
                .HasOne(appointmentService => appointmentService.Service)
                .WithMany(service => service.AppointmentServices)
                .HasForeignKey(appointmentService => appointmentService.ServiceId);

            // TechnicianSchedule to TimeBlock Relationship
            modelBuilder.Entity<TechnicianSchedule>()
                .HasMany(technicianSchedule => technicianSchedule.TimeBlocks)
                .WithOne(timeBlock => timeBlock.TechnicianSchedule)
                .HasForeignKey(timeBlock => timeBlock.TechnicianScheduleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
