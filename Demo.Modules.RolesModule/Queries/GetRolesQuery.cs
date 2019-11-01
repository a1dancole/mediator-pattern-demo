using Demo.Core.Domain.Dto.Roles;
using MediatR;
using System.Collections.Generic;

namespace Demo.Modules.RolesModule.Queries
{
    public class GetRolesQuery : IRequest<IEnumerable<RoleDto>>
    {
        public GetRolesQuery(SearchRolesDto searchDto)
        {
            SearchRolesDto = searchDto;
        }

        public SearchRolesDto SearchRolesDto { get; }
    }
}
