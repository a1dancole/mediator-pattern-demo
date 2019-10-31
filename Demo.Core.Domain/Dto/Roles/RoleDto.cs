using System;
using System.Collections.Generic;
using System.Text;
using Demo.Core.Domain.Dto.Application;

namespace Demo.Core.Domain.Dto.Roles
{
    public class RoleDto
    {
        public Guid RoleId { get; set; }
        public Guid ApplicationId { get; set; }
        public ApplicationDto Application { get; set; }
        public string RoleName { get; set; }
    }
}
