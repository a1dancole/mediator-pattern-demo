﻿using System;

namespace Demo.Core.Domain.Dto.Roles
{
    public class UpdateRoleDto
    {
        public Guid RoleId { get; set; }
        public Guid ApplicationId { get; set; }
        public string RoleName { get; set; }
    }
}
