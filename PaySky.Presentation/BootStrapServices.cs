

using PaySky.Application.Employer.Commands.Employer_Commands;
using PaySky.Application.Employer.Employer_Commands;
using PaySky.Application.Employer.Queries;
using PaySky.Application.Shared.Queries;
using PaySky.Infrastructure.Interfaces;
using PaySky.Infrastructure.Services;

namespace PaySky.Presentation
{
    public class BootStrapServices
    {
        public static void LoadServices(IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
                configuration.RegisterServicesFromAssembly(typeof(CreateVacancyCommand).Assembly);
                configuration.RegisterServicesFromAssembly(typeof(UpdateVacancyCommand).Assembly);
                configuration.RegisterServicesFromAssembly(typeof(DeleteVacancyCommand).Assembly);

                configuration.RegisterServicesFromAssembly(typeof(GetAllVacnciesQuery).Assembly);
                configuration.RegisterServicesFromAssembly(typeof(GetVacancyByIdQuery).Assembly);

                configuration.RegisterServicesFromAssembly(typeof(GetExpiredVacanciesQuery).Assembly);
                configuration.RegisterServicesFromAssembly(typeof(SearchVacancyQuery).Assembly);
            });
            
            services.AddScoped<IVacancyRepository, VacancyRepository>();
            services.AddScoped<IApplicantVacancyRepository, ApplicantVacancyRepository>();
            services.AddScoped<IApplicantRepository, ApplicantRepository>();
            services.AddScoped<IEmployerRepository, EmployerRepository>();

            //services.AddScoped<IVacancyService, VacancyService>();
            //services.AddScoped<IVacancyService, VacancyService>();

        }
    }

}
