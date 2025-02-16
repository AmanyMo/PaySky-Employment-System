using PaySky.Domain.Entities;

namespace PaySky.Infrastructure.Interfaces
{
    public interface IApplicantVacancyRepository:IRepository<ApplicantVacancy>
    {
        string Status();
    }
}
