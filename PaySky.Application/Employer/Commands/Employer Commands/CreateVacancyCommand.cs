
using MediatR;
using PaySky.Domain.Abstract;
using PaySky.Domain.Entities;
using PaySky.Infrastructure.Interfaces;

namespace PaySky.Application.Employer.Employer_Commands
{
    public class CreateVacancyCommand : AbstractVacancy, IRequest<int> //num of row added if >0 success if =0 failed in db-
    {

    }

    public class CreateVacancyCommandHandler : IRequestHandler<CreateVacancyCommand, int>
    {

        private readonly IVacancyRepository _vacancyRepository;
        public CreateVacancyCommandHandler(IVacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }

        public async Task<int> Handle(CreateVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancy = new Vacancy
            {
                Title = request.Title,
                Description = request.Description,
                CreatedDate = request.CreatedDate == default ? DateTime.Now : request.CreatedDate,
                ExpiryDate = request.ExpiryDate,
                MaxApplicant = request.MaxApplicant,
                IsActive=request.IsActive,
                EmployerId=request.EmployerId
            };

            await _vacancyRepository.AddAsync(vacancy);
            await _vacancyRepository.SaveAsync();
            return vacancy.Id;
        }
    }

}
