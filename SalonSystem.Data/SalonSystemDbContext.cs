
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
//using SalonSystem.Models;

namespace SalonSystem.Data 
{
    public class SalonSystemDbContext : DbContext
    {
        public SalonSystemDbContext(DbContextOptions<SalonSystemDbContext> options) : base(options) {}

        public DbSet<Technician> Technicians {get;set;}
        public DbSet<Salon> Salons {get; set;}
        public DbSet<Skill> Skills {get;set;}
        public DbSet<Service> Services {get;set;}

        public DbSet<TechnicianSkill> TechnicianSkills {get;set;}
        public DbSet<ServiceSkill> {get;set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One Salon -Many Technician
            modelBuilder.Entity<Technician>()
                .HasOne(tech => tech.Salon)
                .WithMany(salon => salon.Technicians)
                .HasForeignKey(tech => tech.SalonId);

            // Salon to many Skill
            modelBuilder.Entity<Skill>()
                .hasOne(skill => skill.Salon)
                .WithMany(salon => salon.Services)
                .HasForeignKey(skill => skill.Salonid)


            // Many-to-Many: Technician to Skill 
            modelBuilder.Entity<TechnicianSkill>()
                .HasKey(ts => new { ts.TechnicianId, ts.SkillId });

            modelBuilder.Entity<TechnicianSkill>()
                .HasOne(ts => ts.Technician)
                .WithMany(t => t.Skills)
                .HasForeignKey(ts => ts.TechnicianId);

            modelBuilder.Entity<TechnicianSkill>()
                .HasOne(ts => ts.Skill)
                .WithMany(s => s.TechnicianSkills)
                .HasForeignKey(ts => ts.SkillId);

            // Many-to-Many: Service to Skill
            modelBuilder.Entity<ServiceSkill>()
                .HasKey(ss => new { ss.ServiceId, ss.SkillId });

            modelBuilder.Entity<ServiceSkill>()
                .HasOne(ss => ss.Service)
                .WithMany(s => s.ServiceSkills)
                .HasForeignKey(ss => ss.ServiceId);

            modelBuilder.Entity<ServiceSkill>()
                .HasOne(ss => ss.Skill)
                .WithMany(s => s.ServiceSkills)
                .HasForeignKey(ss => ss.SkillId);
        }

    }
}
