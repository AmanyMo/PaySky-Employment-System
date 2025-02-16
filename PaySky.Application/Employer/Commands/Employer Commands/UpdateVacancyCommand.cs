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

    public class UpdateVacancyCommand : AbstractVacancy, IRequest 
    {

    }

    public class UpdateVacancyCommandHandler : IRequestHandler<UpdateVacancyCommand>
    {

        private readonly IVacancyRepository _vacancyRepository;
        public UpdateVacancyCommandHandler(IVacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }

        public async  Task Handle(UpdateVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancy = new Vacancy
            {
                Id=request.Id,
                Title = request.Title,
                Description = request.Description,
                CreatedDate = request.CreatedDate == default ? DateTime.Now : request.CreatedDate,
                ExpiryDate = request.ExpiryDate,
                MaxApplicant = request.MaxApplicant,
                IsActive = request.IsActive,
            };

             _vacancyRepository.Update(vacancy);
            await _vacancyRepository.SaveAsync();
        }

    }
}
