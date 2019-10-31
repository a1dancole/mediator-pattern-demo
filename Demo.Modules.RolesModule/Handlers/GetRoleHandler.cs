using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Demo.Core.Domain.Dto.Roles;
using Demo.Modules.RolesModule.Queries;
using Demo.Modules.RolesModule.Repository;
using MediatR;

namespace Demo.Modules.RolesModule.Handlers
{
    public class GetRoleHandler : IRequestHandler<GetRoleQuery, RoleDto>
    {
        private readonly IRolesRepository _repository;
        private readonly IMapper _mapper;
        public GetRoleHandler(IRolesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<RoleDto> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var role = await _repository.Get(request.RoleId);
            return _mapper.Map<RoleDto>(role);
        }
    }
}
