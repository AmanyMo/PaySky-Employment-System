using MediatR;
using PaySky.Domain.Entities;
using PaySky.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySky.Application.Shared.Queries
{
    public class SearchVacancyQuery:IRequest<IEnumerable<Vacancy>>
    {
        public string Filter { get; set; }
    }

    public class SearchVacancyQueryHandler : IRequestHandler<SearchVacancyQuery, IEnumerable<Vacancy>>
    {
        private readonly IVacancyRepository _vacancyRepository;
        public SearchVacancyQueryHandler(IVacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }
        public async Task<IEnumerable<Vacancy>> Handle(SearchVacancyQuery request, CancellationToken cancellationToken)
        {
            return await _vacancyRepository.SearchByNameAsync(request.Filter);
        }

    }
}
