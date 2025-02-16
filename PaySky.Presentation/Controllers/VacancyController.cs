using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaySky.Application.Shared.Queries;
using PaySky.Application.Employer.Employer_Commands;
using PaySky.Application.Employer.Commands.Employer_Commands;
using System.Security.Permissions;
using Microsoft.AspNetCore.Authorization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.Extensions.Caching.Memory;
using PaySky.Domain.Entities;

namespace PaySky.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VacancyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _globalOption;

        public VacancyController(IMediator mediator, IMemoryCache memoryCache, MemoryCacheEntryOptions globalOption)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
            _globalOption = globalOption;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVacancies()
        {
            var cashKey = $"Vacanies";
            //var cacheOptions = new MemoryCacheEntryOptions
            //{
            //    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) 
            //};
            //searcha bout token from cashe the from db
            if (_memoryCache.TryGetValue(cashKey, out IEnumerable<Vacancy> cachedVacancies))
            {
                return Ok(cachedVacancies);
            }
            var result = await _mediator.Send(new GetAllVacnciesQuery());

            _memoryCache.Set(cashKey, result, _globalOption);
            return Ok(result);
        }


        [HttpGet("id")]
        public async Task<IActionResult> GetVacancyById([FromQuery]GetVacancyByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "Employer")]
        [HttpPost]
        public async Task<IActionResult> CreateVacancy(CreateVacancyCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAllVacancies), new { id = result }, command);
        }

        [Authorize(Roles = "Employer")]
        [HttpPut]
        public async Task<IActionResult> UpdateVacancy(UpdateVacancyCommand command)
        {
            await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAllVacancies),command);
        }

        [Authorize(Roles = "Employer")]
        [HttpDelete]
        public async Task<IActionResult> DeleteVacancy(DeleteVacancyCommand command)
        {
            await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAllVacancies), command);
        }


        [HttpPost("/search")]
        public async Task<IActionResult> SearchVacancy(SearchVacancyQuery command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }



        //[HttpPost("{vacancyId}/apply")]
        //public async Task<IActionResult> ApplyForVacancy(int vacancyId, [FromBody] int userId)
        //{
        //    var command = new ApplyForVacancyCommand { VacancyId = vacancyId, UserId = userId };
        //    var result = await _mediator.Send(command);
        //    if (!result) return BadRequest("Maximum applications reached for this vacancy.");
        //    return Ok("Application submitted successfully.");
        //}
    }
}
