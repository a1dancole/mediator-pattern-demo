using AutoMapper;
using Demo.Core.Infrastructure;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using SimpleInjector;
using SimpleInjector.Packaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Demo
{
    public class ApiPackage : IPackage
    {
        public ApiPackage()
        {
        }

        public void RegisterServices(Container container)
        {
            container.RegisterSingleton<IMediator, Mediator>();

            container.Collection.Register(typeof(IBusinessRuleValidator<>), GetAssemblies());
            container.Collection.Register(typeof(IValidator<>), GetAssemblies());
            container.Collection.Register(typeof(IRequestHandler<,>), GetAssemblies());

            // we have to do this because by default, generic type definitions (such as the Constrained Notification Handler) won't be registered
            var notificationHandlerTypes = container.GetTypesToRegister(typeof(INotificationHandler<>),
                GetAssemblies(), new TypesToRegisterOptions
                {
                    IncludeGenericTypeDefinitions = true,
                    IncludeComposites = false,
                });

            container.Collection.Register(typeof(INotificationHandler<>), notificationHandlerTypes);

            container.Collection.Register(typeof(IPipelineBehavior<,>), new[] { typeof(FluentValidationHandler<,>), typeof(BusinessRuleValidationHandler<,>) });
            container.Collection.Register(typeof(IRequestPreProcessor<>), Enumerable.Empty<Type>());
            container.Collection.Register(typeof(IRequestPostProcessor<,>), Enumerable.Empty<Type>());

            container.Register(() => new ServiceFactory(container.GetInstance), Lifestyle.Singleton);
            var profiles = GetAssemblies().SelectMany(o => o.GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x)));

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            });

            container.RegisterInstance(config);
            container.Register(() => config.CreateMapper(container.GetInstance));
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            return from file in new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).GetFiles()
                where file.Extension.ToLower() == ".dll" && file.FullName.Contains("Demo")
                select Assembly.Load(AssemblyName.GetAssemblyName(file.FullName));
        }
    }
}
