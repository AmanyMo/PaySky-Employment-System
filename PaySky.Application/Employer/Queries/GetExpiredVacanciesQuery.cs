using MediatR;
using PaySky.Domain.Entities;
using PaySky.Infrastructure.Interfaces;
using PaySky.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySky.Application.Employer.Queries
{
    public class GetExpiredVacanciesQuery :IRequest<IEnumerable<Vacancy>>
    {
        public int EmployerId { get; set; }
    }

    public class GetExpiredVacanciesQueryHandler : IRequestHandler<GetExpiredVacanciesQuery, IEnumerable<Vacancy>>
    {
        private readonly IEmployerRepository _employerRepository;
        public GetExpiredVacanciesQueryHandler(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }
        public async Task<IEnumerable<Vacancy>> Handle(GetExpiredVacanciesQuery request, CancellationToken cancellationToken)
        {
            var result = await _employerRepository.GetExpiredVacancies(request.EmployerId);
            return result.ToList();
        }
    }
}
