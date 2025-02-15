using Microsoft.EntityFrameworkCore;
using PaySky.Domain.Entities;

namespace PaySky.Infrastructure
{
    public class EmploymentDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ApplicantVacancy> Applicant_Vacancy { get; set; }


        public EmploymentDbContext(DbContextOptions<EmploymentDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ApplicantVacancy>()
            .HasKey(av => new { av.UserId, av.VacancyId });

            modelBuilder.Entity<ApplicantVacancy>()
                .HasOne(av => av.User)
                .WithMany(u => u.ApplicantVacancies)
                .HasForeignKey(av => av.UserId);

            modelBuilder.Entity<ApplicantVacancy>()
                .HasOne(av => av.Vacancy)
                .WithMany(v => v.ApplicantVacancies)
                .HasForeignKey(av => av.VacancyId);


            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<Vacancy>()
            .HasOne(v => v.Employer)
            .WithMany(u => u.Vacancies)
            .HasForeignKey(v => v.EmployerId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>()
                .HasData(
                   new Role { Id=1,Name="Employer"},
                   new Role { Id = 2, Name = "Applicant" }
            );

        }
    }
}
