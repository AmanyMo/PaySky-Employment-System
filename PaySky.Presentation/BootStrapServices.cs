

using PaySky.Infrastructure.Interfaces;
using PaySky.Infrastructure.Services;

namespace PaySky.Presentation
{
    public class BootStrapServices
    {
        public static void LoadServices(IServiceCollection services)
        {
            services.AddScoped<IVacancyRepository, VacancyRepository>();
            //services.AddScoped<IVacancyService, VacancyService>();

            services.AddScoped<IApplicantVacancyRepository, ApplicantVacancyRepository>();
            //services.AddScoped<IVacancyRepository, VacancyRepository>();

            //services.AddScoped<IVacancyRepository, VacancyRepository>();
            //services.AddScoped<IVacancyService, VacancyService>();

            //services.AddScoped<IVacancyService, VacancyService>();
            //services.AddScoped<IVacancyService, VacancyService>();

        }
    }

}
