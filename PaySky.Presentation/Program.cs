using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.OpenApi.Models;
using PaySky.Infrastructure;
using PaySky.Infrastructure.Services;
using PaySky.Presentation;
using PaySky.Presentation.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);
//var globalCacheOptions = new MemoryCacheEntryOptions
//{
//    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60) // Cache for 60 seconds
//};
//builder.Services.AddDbContext
builder.Services.AddDbContext<EmploymentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PaySkyDatabaseAConnection")));

//bootsratping service DI
BootStrapServices.LoadServices(builder.Services,builder.Configuration);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "PaySky API", Version = "v1" });

    // Add JWT support in Swagger
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter JWT Bearer token **_only_**",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, Array.Empty<string>() }
    });
});




var app = builder.Build();


app.UseExceptionHandler(new ExceptionHandlerOptions
{
    ExceptionHandler = new GlobalExceptionMiddleware().Invoke
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
