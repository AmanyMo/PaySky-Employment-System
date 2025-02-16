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
    public class GetApplicantsForVacancyQuery:IRequest<IEnumerable<User>>
    {
        public int vacancyId { get; set; }
    }

     public class GetApplicantForVacancyQueryHandler : IRequestHandler<GetApplicantsForVacancyQuery, IEnumerable<User>>
    {
        private readonly IEmployerRepository _employerRepository;
        public GetApplicantForVacancyQueryHandler(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }

        public async Task<IEnumerable<User>> Handle(GetApplicantsForVacancyQuery request, CancellationToken cancellationToken)
        {
            return await _employerRepository.GetApplicantsForVacancy(request.vacancyId);
        }
    }


}
