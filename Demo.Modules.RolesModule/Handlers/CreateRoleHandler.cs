using AutoMapper;
using Demo.Core.Domain.Dto.Roles;
using Demo.Core.Domain.Models;
using Demo.Modules.RolesModule.Commands;
using Demo.Modules.RolesModule.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Modules.RolesModule.Handlers
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, RoleDto>
    {
        private readonly IRolesRepository _repository;
        private readonly IMapper _mapper;
        public CreateRoleHandler(IRolesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<RoleDto> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = _mapper.Map<Role>(request.CreateRoleDto);
            var result = await _repository.Create(role);
            return _mapper.Map<RoleDto>(result);
        }
    }
}
