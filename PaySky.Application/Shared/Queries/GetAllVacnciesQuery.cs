using MediatR;
using PaySky.Domain.Entities;
using PaySky.Infrastructure.Interfaces;

namespace PaySky.Application.Shared.Queries
{
    public class GetAllVacnciesQuery : IRequest<IEnumerable<Vacancy>>
    {


    }

    public class GetAllVacanciesQueryHandler : IRequestHandler<GetAllVacnciesQuery, IEnumerable<Vacancy>>
    {
        private readonly IVacancyRepository _vacancyRepository;
        public GetAllVacanciesQueryHandler(IVacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }
        public async Task<IEnumerable<Vacancy>> Handle(GetAllVacnciesQuery request, CancellationToken cancellationToken)
        {
            return await _vacancyRepository.GetAllAsync();
        }
    }
}
