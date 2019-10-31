using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Demo.Core.Domain.Models;
using Demo.Modules.RolesModule.Commands;
using Demo.Modules.RolesModule.Repository;
using MediatR;

namespace Demo.Modules.RolesModule.Handlers
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, bool>
    {
        private readonly IRolesRepository _rolesRepository;
        private readonly IMapper _mapper;

        public DeleteRoleHandler(IRolesRepository repository, IMapper mapper)
        {
            _rolesRepository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = _mapper.Map<Role>(request.DeleteRoleDto);
            return await _rolesRepository.Delete(role);
        }
    }
}
