using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Domain.Dto.Roles
{
    public class DeleteRoleDto
    {
        public Guid RoleId { get; set; }
        public Guid ApplicationId { get; set; }
        public string RoleName { get; set; }
    }
}
