using Microsoft.EntityFrameworkCore;
using PaySky.Domain.Entities;
using PaySky.Infrastructure.Interfaces;


namespace PaySky.Infrastructure.Services
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly EmploymentDbContext _context;
        public EmployerRepository(EmploymentDbContext context)
        {
                _context = context;
        }
        public async Task<IEnumerable<Vacancy>> GetExpiredVacancies(int employerId)
        {
            return await _context.Vacancies
                .Where(v=>v.EmployerId ==employerId && v.ExpiryDate<DateTime.Today).ToListAsync();
        }

        async Task<IEnumerable<User>> IEmployerRepository.GetApplicantsForVacancy(int vacancyId)
        {
            return await _context.Users
                .Where(u => u.ApplicantVacancies.Any(av => av.VacancyId == vacancyId)).ToListAsync();
        }

    }
}
