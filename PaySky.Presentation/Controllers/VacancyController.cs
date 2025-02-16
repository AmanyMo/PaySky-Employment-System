using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaySky.Application.Applicant.Applicant_Queries;
using PaySky.Application.Employer.Employer_Commands;

namespace PaySky.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost]
        public async Task<IActionResult> CreateVacancy(CreateVacancyCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAllVacancies), new { id = result }, command);
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
