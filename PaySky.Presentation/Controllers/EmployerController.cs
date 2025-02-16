using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PaySky.Application.Employer.Queries;
using PaySky.Application.Shared.Queries;
using PaySky.Domain.Entities;

namespace PaySky.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Employer")]
    public class EmployerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _globalOption;
        public EmployerController(IMediator mediator, IMemoryCache memoryCache, MemoryCacheEntryOptions globalOption)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
            _globalOption = globalOption;
        }
        [HttpPost("expired")]
        public async Task<IActionResult> GetExpiredVacancies(GetExpiredVacanciesQuery query)
        {
            var cashKey = $"ExpiredVacanies-for-{query.EmployerId}";
            if (_memoryCache.TryGetValue(cashKey, out IEnumerable<Vacancy> cachedEXPVacancies))
                return Ok(cachedEXPVacancies);

            var result = await _mediator.Send(query);
            _memoryCache.Set(cashKey, result, _globalOption);
            return Ok(result);
        }
        [HttpPost("applicant")]
        public async Task<IActionResult> GetApplicantForVacancy(GetApplicantsForVacancyQuery query)
        {
            var cashKey = $"Applicants-For-Vacany_{query.vacancyId}";
            if (_memoryCache.TryGetValue(cashKey, out IEnumerable<Vacancy> cachedEXPVacancies))
                return Ok(cachedEXPVacancies);

            var result = await _mediator.Send(query);
            _memoryCache.Set(cashKey, result, _globalOption);
            return Ok(result);
        }



    }
}
