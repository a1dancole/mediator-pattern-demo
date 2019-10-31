using System;
using System.Threading.Tasks;
using Demo.Core.Domain.Dto.Roles;
using Demo.Modules.RolesModule.Commands;
using Demo.Modules.RolesModule.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{roleId}")]
        public async Task<IActionResult> GetRole([FromRoute] Guid roleId)
        {
            var response = await _mediator.Send(new GetRoleQuery(roleId));
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> SearchRoles([FromRoute] SearchRolesDto searchDto)
        {
            var response = await _mediator.Send(new GetRolesQuery(searchDto));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto roleDto)
        {
            var response = await _mediator.Send(new CreateRoleCommand(roleDto));
            return Ok(response);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleDto updateDto)
        {
            var response = await _mediator.Send(new UpdateRoleCommand(updateDto));
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRole([FromBody] DeleteRoleDto deleteDto)
        {
            var response = await _mediator.Send(new DeleteRoleCommand(deleteDto));
            return Ok(response);
        }
    }
}