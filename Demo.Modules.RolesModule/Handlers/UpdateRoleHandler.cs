using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Demo.Core.Domain.Dto.Roles;
using Demo.Core.Domain.Models;
using Demo.Modules.RolesModule.Commands;
using Demo.Modules.RolesModule.Repository;
using MediatR;

namespace Demo.Modules.RolesModule.Handlers
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, RoleDto>
    {
        private readonly IRolesRepository _repository;
        private readonly IMapper _mapper;
        public UpdateRoleHandler(IRolesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<RoleDto> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = _mapper.Map<Role>(request.UpdateRoleDto);
            var response = await _repository.Update(role);
            return _mapper.Map<RoleDto>(response);
        }
    }
}
