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
            //Check about 24h
            var app_vac = new ApplicantVacancy
            {
                UserId = request.applicantId,
                VacancyId = request.vacancyId
            };
            var lastApplication = await _applicantVacancy.GetLastApplication(app_vac);

            if (lastApplication != null && (DateTime.UtcNow - lastApplication.AppliedDate).TotalHours < 24)
            {
                //go to my exception middleware ..
                throw new InvalidOperationException("You are not allowed to apply for more than one vacancy per day.");
            }

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
