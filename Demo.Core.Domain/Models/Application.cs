using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Core.Domain.Models
{
    public class Application
    {
        [Key]
        public Guid ApplicationId { get; set; }

        public string ApplicationName { get; set; }
    }
}
