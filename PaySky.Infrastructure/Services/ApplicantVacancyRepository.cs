using Microsoft.EntityFrameworkCore;
using PaySky.Domain.Entities;
using PaySky.Infrastructure.Interfaces;

namespace PaySky.Infrastructure.Services
{
    public class ApplicantVacancyRepository : IApplicantVacancyRepository
    {
        private readonly EmploymentDbContext _context;
        public ApplicantVacancyRepository(EmploymentDbContext context)
        {
                _context = context;
        }

        public async Task AddAsync(ApplicantVacancy applicantVacancy)
        {
            await _context.Applicant_Vacancy.AddAsync(applicantVacancy);
        }
        public void Update(ApplicantVacancy applicantVacancy)
        {
            _context.Applicant_Vacancy.Update(applicantVacancy);
        }

        public async Task Delete(ApplicantVacancy applicantVacancy)
        {
            
            var app_vac = await _context.Applicant_Vacancy.FindAsync(applicantVacancy.UserId, applicantVacancy.VacancyId);
            if (app_vac != null)
                _context.Applicant_Vacancy.Remove(applicantVacancy);
        }


        public async Task<IEnumerable<ApplicantVacancy>> GetAllAsync()
        {
            return await _context.Applicant_Vacancy.ToListAsync();
        }

        public async Task<ApplicantVacancy> GetByIdAsync(int id)
        {
            return await _context.Applicant_Vacancy.FindAsync(id);

        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public string Status()
        {
            return "Applied";
        }

        public async Task<ApplicantVacancy> GetLastApplication(ApplicantVacancy application)
        {
            return await _context.Applicant_Vacancy
                .Where(av => av.UserId == application.UserId)
                .OrderByDescending(av => av.AppliedDate).FirstOrDefaultAsync();
 
        }
    }
}
