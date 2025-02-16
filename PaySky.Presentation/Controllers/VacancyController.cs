using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaySky.Application.Shared.Queries;
using PaySky.Application.Employer.Employer_Commands;
using PaySky.Application.Employer.Commands.Employer_Commands;
using System.Security.Permissions;
using Microsoft.AspNetCore.Authorization;

namespace PaySky.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VacancyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VacancyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVacancies()
        {
            var result = await _mediator.Send(new GetAllVacnciesQuery());
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
