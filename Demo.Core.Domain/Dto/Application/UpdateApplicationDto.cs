using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Domain.Dto.Application
{
    public class UpdateApplicationDto
    {
        public Guid ApplicationId { get; set; }
        public string ApplicationName { get; set; }
     }
}
