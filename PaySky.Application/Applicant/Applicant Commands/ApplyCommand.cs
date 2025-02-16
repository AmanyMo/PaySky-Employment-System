using MediatR;
using PaySky.Domain.Entities;
using PaySky.Infrastructure.Interfaces;

namespace PaySky.Application.Applicant.Applicant_Commands
{
    public class ApplyCommand:IRequest<bool>
    {
        public int vacancyId { get; set; }
        public int applicantId { get; set; }
    }



    public class ApplyCommandHandler : IRequestHandler<ApplyCommand, bool>
    {
        private readonly IApplicantVacancyRepository _applicantVacancy;
        private readonly IVacancyRepository _vacancyRepository;

        public ApplyCommandHandler(IApplicantVacancyRepository applicantVacancy, IVacancyRepository vacancyRepository)
        {
            _applicantVacancy = applicantVacancy;
            _vacancyRepository = vacancyRepository;

        }

        public async Task<bool> Handle(ApplyCommand request, CancellationToken cancellationToken)
        {
            if (await _vacancyRepository.IsMaxReached(request.vacancyId))
                        return false; // Max applications reached
           

            var application = new ApplicantVacancy
            {
                VacancyId = request.vacancyId,
                UserId = request.applicantId,
                AppliedDate = DateTime.UtcNow,
                
            };

            await _applicantVacancy.AddAsync(application);
            await _applicantVacancy.SaveAsync();
            return true;
        }

      
    }
}
