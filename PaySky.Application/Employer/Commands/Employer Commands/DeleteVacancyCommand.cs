using MediatR;
using PaySky.Domain.Abstract;
using PaySky.Domain.Entities;
using PaySky.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySky.Application.Employer.Commands.Employer_Commands
{
    public class DeleteVacancyCommand: AbstractVacancy, IRequest
    {
    }

    public class DeleteVacancyCommandHandler : IRequestHandler<DeleteVacancyCommand>
    {

        private readonly IVacancyRepository _vacancyRepository;
        public DeleteVacancyCommandHandler(IVacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }

        public async Task Handle(DeleteVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancy = new Vacancy
            {
                Title = request.Title,
                Description = request.Description,
                CreatedDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow,
                MaxApplicant = request.MaxApplicant,
            };

            _vacancyRepository.Delete(vacancy);
            await _vacancyRepository.SaveAsync();
        }

    }
}
