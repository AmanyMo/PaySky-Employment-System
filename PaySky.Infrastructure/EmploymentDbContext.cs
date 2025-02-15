using Microsoft.EntityFrameworkCore;
using PaySky.Domain.Entities;

namespace PaySky.Infrastructure
{
    public class EmploymentDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ApplicantVacancy> ApplicantVacancy { get; set; }


        public EmploymentDbContext(DbContextOptions<EmploymentDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vacancy>()
            .HasOne(v => v.Employer)
            .WithMany(u => u.Vacancies)
            .HasForeignKey(v => v.EmployerId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>()
                .HasData(
                   new Role { Id=1,Name="Employer"},
                   new Role { Id = 1, Name = "Applicant" }
            );

        }
    }
}
