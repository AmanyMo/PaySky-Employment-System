using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaySky.Domain.Entities;
using PaySky.Infrastructure.Interfaces;

namespace PaySky.Infrastructure.Services
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly EmploymentDbContext _context;
        public VacancyRepository(EmploymentDbContext context)
        {
                _context = context;
        }

        public async Task AddAsync(Vacancy vacancy)
        {
            await _context.Vacancies.AddAsync(vacancy);
        }
        public void Update(Vacancy vacancy)
        {
            _context.Vacancies.Update(vacancy);
        }
        public async Task Delete(Vacancy vacancy)
        {
            // _context.Vacancies.Remove(vacancy);
            var vac = await _context.Vacancies.FindAsync(vacancy.Id);
            if (vac != null)
                _context.Vacancies.Remove(vacancy);

        }

        public async Task<IEnumerable<Vacancy>> GetAllAsync()
        {
            return await _context.Vacancies.ToListAsync();
        }

        public async Task<Vacancy> GetByIdAsync(int id)
        {
          return  await _context.Vacancies.FindAsync(id);
        }

        public async Task<bool> IsMaxReached(int vacancyId)
        {
            //calculate the num from relation or add count fireld to vacancy table and accumlate it 
            var vacancy = await _context.Vacancies
            .Include(v => v.ApplicantVacancies)
            .FirstOrDefaultAsync(v => v.Id == vacancyId);

            return (vacancy?.ApplicantVacancies?.Count >= vacancy?.MaxApplicant);
        }

        async Task<IEnumerable<Vacancy>> ISearchRepository<Vacancy>.SearchByNameAsync(string filter)
        {
            var vacs=await _context.Vacancies
                .Where( v => v.Title.ToLower().Contains(filter.ToLower())
                     || v.Description.ToLower().Contains(filter.ToLower())).ToListAsync();
            return vacs;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
