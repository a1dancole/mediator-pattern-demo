using System;
using Demo.Core.Domain.Dto.Roles;
using MediatR;

namespace Demo.Modules.RolesModule.Queries
{
    public class GetRoleQuery : IRequest<RoleDto>
    {
        public GetRoleQuery(Guid id)
        {
            RoleId = id;
        }

        public Guid RoleId { get; }
    }
}
