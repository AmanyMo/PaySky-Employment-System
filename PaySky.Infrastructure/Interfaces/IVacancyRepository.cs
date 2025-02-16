using PaySky.Domain.Entities;

namespace PaySky.Infrastructure.Interfaces
{
    public interface IVacancyRepository : IRepository<Vacancy>, ISearchRepository<Vacancy>
    {
        Task<bool> IsMaxReached(int vacancyId);
    }
}
