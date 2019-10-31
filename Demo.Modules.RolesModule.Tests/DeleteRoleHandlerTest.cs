using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Demo.Core.Domain.Dto.Roles;
using Demo.Core.Domain.Models;
using Demo.Core.Infrastructure;
using Demo.Modules.RolesModule.Commands;
using Demo.Modules.RolesModule.Configuration;
using Demo.Modules.RolesModule.Handlers;
using Demo.Modules.RolesModule.Repository;
using Moq;
using Xunit;

namespace Demo.Modules.RulesModule.Tests
{
    public class DeleteRoleHandlerTest
    {
        [Fact]
        public async Task DeleteRoleHandler_IsSuccessful_ReturnsTrue()
        {
            //Setup
            var repository = new Mock<IRolesRepository>();
            repository.Setup(o => o.Delete(It.IsAny<Role>())).ReturnsAsync(true);

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();

            var handler = new DeleteRoleHandler(repository.Object, mapper);

            //Act
            var response = await handler.Handle(new DeleteRoleCommand(new DeleteRoleDto { ApplicationId = Guid.NewGuid(), RoleName = "test" }), default);

            //Assert
            Assert.True(response);
        }

        [Fact]
        public async Task DeleteRoleHandler_BusinessValidationFails_ThrowsException()
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

            var handler = new DeleteRoleBusinessRuleValidationHandler(repository.Object);

            //Act
            var result = handler.Validate(new DeleteRoleCommand(new DeleteRoleDto { ApplicationId = Guid.Empty, RoleName = "TestRole", RoleId = Guid.NewGuid()}));

            //Assert
            await Assert.ThrowsAsync<BusinessRuleValidationException>(async () => await result);
        }

        [Fact]
        public async Task DeleteRoleHandler_BusinessValidationPasses_DoesNotThrowException()
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

            var handler = new DeleteRoleBusinessRuleValidationHandler(repository.Object);

            //Act
            var result = await Record.ExceptionAsync(async () => await handler.Validate(new DeleteRoleCommand(new DeleteRoleDto { ApplicationId = Guid.Empty, RoleName = "TestRole" })));

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task DeleteRoleHandler_FluentValidationHandler_ThrowsValidationException()
        {
            //Setup
            var command = new DeleteRoleCommand(new DeleteRoleDto { ApplicationId = Guid.NewGuid() });
            var validator = new DeleteRoleCommandValidator();

            //Action
            var result = await validator.ValidateAsync(command);

            //Assert
            Assert.Contains(result.Errors, o => o.ErrorMessage == "RoleId cannot be empty");
        }
    }
}
