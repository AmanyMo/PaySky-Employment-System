using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaySky.Application.Applicant.Applicant_Commands;

namespace PaySky.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Applicant")]
    public class ApplicantController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ApplicantController(IMediator mediator)
        {
                _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> ApplyVacancy(ApplyCommand command)
        {
            var result= await _mediator.Send(command);
            return Ok(result);
        }
    }
}
