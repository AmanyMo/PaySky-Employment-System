using MediatR;
using PaySky.Domain.Entities;
using PaySky.Infrastructure.Interfaces;


namespace PaySky.Application.Shared.Queries
{
    public class GetVacancyByIdQuery:IRequest<Vacancy>
    {
        public int id { get; set; }
    }

    public class GetVacancyByIdQueryHandler : IRequestHandler<GetVacancyByIdQuery, Vacancy>
    {
        private readonly IVacancyRepository _vacancyRepository;
        public GetVacancyByIdQueryHandler(IVacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }
        public async Task<Vacancy> Handle(GetVacancyByIdQuery request, CancellationToken cancellationToken)
        {
            return await _vacancyRepository.GetByIdAsync(request.id);
        }

    }
}
