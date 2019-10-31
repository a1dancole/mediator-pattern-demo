using System;
using System.Threading.Tasks;
using Demo.Core.Domain.Dto.Application;
using Demo.Modules.ApplicationModule.Commands;
using Demo.Modules.ApplicationModule.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ApplicationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{applicationId}")]
        public async Task<IActionResult> GetApplication([FromRoute] Guid applicationId)
        {
            var response = await _mediator.Send(new GetApplicationQuery(applicationId));

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> SearchApplications([FromRoute] SearchApplicationDto searchDto)
        {
            var response = await _mediator.Send(new GetApplicationsQuery(searchDto));

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication([FromBody] CreateApplicationDto createDto)
        {
            var response = await _mediator.Send(new CreateApplicationCommand(createDto));

            return Ok(response);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateApplication([FromBody] UpdateApplicationDto updateDto)
        {
            var response = await _mediator.Send(new UpdateApplicationCommand(updateDto));

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteApplication([FromBody] DeleteApplicationDto deleteDto)
        {
            var response = await _mediator.Send(new DeleteApplicationCommand(deleteDto));

            return Ok(response);
        }
    }
}