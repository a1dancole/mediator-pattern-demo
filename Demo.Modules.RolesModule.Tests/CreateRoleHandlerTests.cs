using AutoMapper;
using Demo.Core.Domain.Dto.Roles;
using Demo.Core.Domain.Models;
using Demo.Core.Infrastructure;
using Demo.Modules.RolesModule.Commands;
using Demo.Modules.RolesModule.Configuration;
using Demo.Modules.RolesModule.Handlers;
using Demo.Modules.RolesModule.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace Demo.Modules.RulesModule.Tests
{
    public class CreateRoleHandlerTests
    {
        [Fact]
        public async Task CreateRoleHandler_IsSuccessful_ReturnsRole()
        {
            //Setup
            var repository = new Mock<IRolesRepository>();
            repository.Setup(o => o.Create(It.IsAny<Role>())).ReturnsAsync(new Role
            {
                ApplicationId = Guid.Empty,
                RoleName = "Test",
                RoleId = Guid.Empty,
            });
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();

            var handler = new CreateRoleHandler(repository.Object, mapper);

            //Act
            var response = await handler.Handle(new CreateRoleCommand(new CreateRoleDto { ApplicationId = Guid.NewGuid(), RoleName = "test" }), default);

            //Assert
            Assert.NotNull(response);
            Assert.True(response.RoleName.Equals("Test"));
        }

        [Fact]
        public async Task CreateRoleHandler_BusinessValidationFails_BusinessRuleIsBroken()
        {
            //Setup
            var repository = new Mock<IRolesRepository>();
            repository.Setup(o => o.Find(It.IsAny<Expression<Func<Role, bool>>>())).ReturnsAsync(new List<Role>
            {
                new Role
                {
                    ApplicationId = Guid.Empty,
                    RoleName = "TestRole",
                    RoleId = Guid.Empty
                }
            }.AsQueryable());

            var handler = new CreateRoleBusinessRuleValidationHandler(repository.Object);

            //Act
            var result = await handler.Validate(new CreateRoleCommand(new CreateRoleDto { ApplicationId = Guid.Empty, RoleName = "TestRole" }));
            //Assert
            Assert.True(result.IsBroken());
        }

        [Fact]
        public async Task CreateRoleHandler_BusinessValidationPasses_DoesNotThrowException()
        {
            //Setup
            var repository = new Mock<IRolesRepository>();
            repository.Setup(o => o.Find(It.IsAny<Expression<Func<Role, bool>>>())).ReturnsAsync(new List<Role>().AsQueryable());

            var handler = new CreateRoleBusinessRuleValidationHandler(repository.Object);

            //Act
            var result = await Record.ExceptionAsync(async () => await handler.Validate(new CreateRoleCommand(new CreateRoleDto { ApplicationId = Guid.Empty, RoleName = "TestRole" })));

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateRoleHandler_FluentValidationHandler_ThrowsValidationException()
        {
            //Setup
            var command = new CreateRoleCommand(new CreateRoleDto { ApplicationId = Guid.NewGuid() });
            var validator = new CreateRoleCommandValidator();

            //Action
            var result = await validator.ValidateAsync(command);

            //Assert
            Assert.Contains(result.Errors, o => o.ErrorMessage == "RoleName cannot be empty");
        }
    }
}
