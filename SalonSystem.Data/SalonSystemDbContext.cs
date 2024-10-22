
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SalonSystem.Models.Salons;
using SalonSystem.Models.Technicians;
using SalonSystem.Models.Skills;
using SalonSystem.Models.Services;
namespace SalonSystem.Data 
{
    public partial class SalonSystemDbContext : DbContext
    {
        public SalonSystemDbContext(DbContextOptions<SalonSystemDbContext> options) : base(options) {}

        public DbSet<Technician> Technicians {get;set;}
        public DbSet<Salon> Salons {get; set;}
        public DbSet<Skill> Skills {get;set;}
        public DbSet<Service> Services {get;set;}

        public DbSet<TechnicianSkill> TechnicianSkills {get;set;}
        public DbSet<ServiceSkill> ServiceSkills {get;set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One Salon -Many Technician
            modelBuilder.Entity<Technician>()
                .HasOne(tech => tech.AssociatedSalon)
                .WithMany(salon => salon.Technicians)
                .HasForeignKey(tech => tech.SalonId);

            // Salon to many Skill
            modelBuilder.Entity<Skill>()
                .HasOne(skill => skill.AssociatedSalon)
                .WithMany(salon => salon.Skills)
                .HasForeignKey(skill => skill.SalonId);

            //Salon to many Service
            modelBuilder.Entity<Service>()
                .HasOne(service => service.AssociatedSalon)
                .WithMany(salon => salon.Services)
                .HasForeignKey(service => service.SalonId);


            // Many-to-Many: Technician to Skill 
            modelBuilder.Entity<TechnicianSkill>()
                .HasKey(ts => new { ts.TechnicianId, ts.SkillId });

            modelBuilder.Entity<TechnicianSkill>()
                .HasOne(ts => ts.Technician)
                .WithMany(tech => tech.TechnicianSkills)
                .HasForeignKey(ts => ts.TechnicianId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TechnicianSkill>()
                .HasOne(ts => ts.Skill)
                .WithMany(skill => skill.TechnicianSkills)
                .HasForeignKey(ts => ts.SkillId)
                .OnDelete(DeleteBehavior.Restrict);

            // Many-to-Many: Service to Skill
            modelBuilder.Entity<ServiceSkill>()
                .HasKey(ss => new { ss.ServiceId, ss.SkillId });

            modelBuilder.Entity<ServiceSkill>()
                .HasOne(ss => ss.Service)
                .WithMany(service => service.ServiceSkills)
                .HasForeignKey(ss => ss.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ServiceSkill>()
                .HasOne(ss => ss.Skill)
                .WithMany(skill=> skill.ServiceSkills)
                .HasForeignKey(ss => ss.SkillId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
