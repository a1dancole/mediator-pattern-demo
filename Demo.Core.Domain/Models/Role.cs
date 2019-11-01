using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Core.Domain.Models
{
    public class Role
    {
        public Guid RoleId { get; set; }
        public Guid ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        public Application Application { get; set; }
        public string RoleName { get; set; }
    }
}
