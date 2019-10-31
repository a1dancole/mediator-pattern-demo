using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Demo.Core.Domain.Dto.Application;
using Demo.Core.Domain.Dto.Roles;
using Demo.Core.Domain.Models;
using Demo.Core.Infrastructure;
using Demo.Modules.ApplicationModule.Commands;
using Demo.Modules.ApplicationModule.Configuration;
using Demo.Modules.ApplicationModule.Handlers;
using Moq;
using Xunit;

namespace Demo.Modules.ApplicationModule.Tests
{
    public class CreateApplicationHandlerTests
    {
        [Fact]
        public async Task CreateApplicationHandler_IsSuccessful_ReturnsApplication()
        {
            //Setup
            var repository = new Mock<IApplicationRepository>();
            repository.Setup(o => o.Create(It.IsAny<Application>())).ReturnsAsync(new Application
            {
                ApplicationId = Guid.Empty,
                ApplicationName = "Test"
            });
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();

            var handler = new CreateApplicationHandler(repository.Object, mapper);

            //Act
            var response = await handler.Handle(new CreateApplicationCommand(new CreateApplicationDto { ApplicationName = "Test" }), default);

            //Assert
            Assert.NotNull(response);
            Assert.True(response.ApplicationName.Equals("Test"));
        }

        [Fact]
        public async Task CreateApplicationHandler_BusinessValidationFails_ThrowsException()
        {
            //Setup
            var repository = new Mock<IApplicationRepository>();
            repository.Setup(o => o.Find(It.IsAny<Expression<Func<Application, bool>>>())).ReturnsAsync(new List<Application>
            {
                new Application
                {
                    ApplicationId = Guid.Empty,
                    ApplicationName = "Test"
                }
            }.AsQueryable());

            var handler = new CreateApplicationBusinessRuleValidationHandler(repository.Object);

            //Act
            var result = handler.Validate(new CreateApplicationCommand(new CreateApplicationDto { ApplicationName = "Test"}));
            //Assert
            await Assert.ThrowsAsync<BusinessRuleValidationException>(async () => await result);
        }


        [Fact]
        public async Task CreateRoleHandler_BusinessValidationPasses_DoesNotThrowException()
        {
            //Setup
            var repository = new Mock<IApplicationRepository>();
            repository.Setup(o => o.Find(It.IsAny<Expression<Func<Application, bool>>>())).ReturnsAsync(new List<Application>().AsQueryable());

            var handler = new CreateApplicationBusinessRuleValidationHandler(repository.Object);

            //Act
            var result = await Record.ExceptionAsync(async () => await handler.Validate(new CreateApplicationCommand(new CreateApplicationDto { ApplicationName = "Test" })));

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateRoleHandler_FluentValidationHandler_ThrowsValidationException()
        {
            //Setup
            var command = new CreateApplicationCommand(new CreateApplicationDto());
            var validator = new CreateApplicationCommandValidator();

            //Action
            var result = await validator.ValidateAsync(command);

            //Assert
            Assert.Contains(result.Errors, o => o.ErrorMessage == "ApplicationName cannot be empty");
        }
    }
}
