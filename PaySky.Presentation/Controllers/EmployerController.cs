using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaySky.Application.Employer.Queries;
using PaySky.Application.Shared.Queries;

namespace PaySky.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Employer")]
    public class EmployerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("expired")]
        public async Task<IActionResult> GetExpiredVacancies(GetExpiredVacanciesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPost("applicant")]
        public async Task<IActionResult> GetApplicantForVacancy(GetApplicantsForVacancyQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }



    }
}
