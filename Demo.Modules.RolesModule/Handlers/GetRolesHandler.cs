using AutoMapper;
using Demo.Core.Domain.Dto.Roles;
using Demo.Modules.RolesModule.Queries;
using Demo.Modules.RolesModule.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Modules.RolesModule.Handlers
{
    public class GetRolesHandler : IRequestHandler<GetRolesQuery, IEnumerable<RoleDto>>
    {
        private readonly IRolesRepository _repository;
        private readonly IMapper _mapper;

        public GetRolesHandler(IRolesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _repository.Find(o =>
                o.RoleName.Contains(request.SearchRolesDto.SearchTerm, StringComparison.CurrentCultureIgnoreCase));

            return _mapper.Map<IEnumerable<RoleDto>>(roles);
        }
    }
}
