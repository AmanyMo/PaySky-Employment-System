

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using PaySky.Application.Employer.Commands.Employer_Commands;
using PaySky.Application.Employer.Employer_Commands;
using PaySky.Application.Employer.Queries;
using PaySky.Application.Shared.Commands;
using PaySky.Application.Shared.Queries;
using PaySky.Infrastructure.Interfaces;
using PaySky.Infrastructure.Services;
using System.Text;

namespace PaySky.Presentation
{
    public class BootStrapServices
    {
        public static void LoadServices(IServiceCollection services,IConfiguration configuration)
        {
            //caching global optionnnn::
            var globalCacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60) // Cache for 60 seconds
            };


            //Jwt configuration starts here
            var jwtIssuer = configuration.GetSection("Jwt:Issuer").Get<string>();
            var jwtKey = configuration.GetSection("Jwt:SecretKey").Get<string>();
            var jwtAudience = configuration.GetSection("Jwt:Audience").Get<string>();

            services.AddSingleton<Jwt>(provider =>
                    new Jwt(
                        jwtKey,
                        jwtIssuer,
                        jwtAudience
              ));


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateAudience = true,

                        ValidIssuer = jwtIssuer,
                        ValidAudience = jwtAudience,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),

                       // RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                    };
                    options.IncludeErrorDetails = true; //for dev not production (don't tell user what happen :) )
                });


            services.AddAuthorization(options =>
            {
                options.AddPolicy("Employer-Only", policy => policy.RequireRole("Employer"));
                options.AddPolicy("Applicant-Only", policy => policy.RequireRole("Applicant"));

            });


            //add mediatorR to manage CQRS
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

                configuration.RegisterServicesFromAssembly(typeof(RegisterUserCommand).Assembly);
                configuration.RegisterServicesFromAssembly(typeof(LoginUserQuery).Assembly);
            });


            //add cache::
            services.AddMemoryCache();
            services.AddSingleton(globalCacheOptions);

            //register DI
            services.AddScoped<IVacancyRepository, VacancyRepository>();
            services.AddScoped<IApplicantVacancyRepository, ApplicantVacancyRepository>();
            services.AddScoped<IApplicantRepository, ApplicantRepository>();
            services.AddScoped<IEmployerRepository, EmployerRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IVacancyService, VacancyService>();

        }
    }

}
