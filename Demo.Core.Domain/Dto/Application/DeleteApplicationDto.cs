using System;

namespace Demo.Core.Domain.Dto.Application
{
    public class DeleteApplicationDto
    {
        public Guid ApplicationId { get; set; }
        public string ApplicationName { get; set; }
    }
}
