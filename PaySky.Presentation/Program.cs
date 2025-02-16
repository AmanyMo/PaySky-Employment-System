using Microsoft.EntityFrameworkCore;
using PaySky.Application.Employer.Commands.Employer_Commands;
using PaySky.Application.Employer.Employer_Commands;
using PaySky.Application.Shared.Queries;
using PaySky.Infrastructure;
using PaySky.Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//add the mediator DP 
//builder.Services.AddMediatR(configuration =>
//{
//    configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
//    configuration.RegisterServicesFromAssembly(typeof(CreateVacancyCommand).Assembly);
//    configuration.RegisterServicesFromAssembly(typeof(UpdateVacancyCommand).Assembly);
//    configuration.RegisterServicesFromAssembly(typeof(DeleteVacancyCommand).Assembly);

//    configuration.RegisterServicesFromAssembly(typeof(GetAllVacnciesQuery).Assembly);
//    configuration.RegisterServicesFromAssembly(typeof(GetVacancyByIdQuery).Assembly);
//});

//builder.Services.AddDbContext
builder.Services.AddDbContext<EmploymentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PaySkyDatabaseAConnection")));
//bootsratping service DI
BootStrapServices.LoadServices(builder.Services);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
