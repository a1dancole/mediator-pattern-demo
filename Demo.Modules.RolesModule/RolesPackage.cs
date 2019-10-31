using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Demo.Modules.RolesModule.Repository;
using MediatR;
using MediatR.Pipeline;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Demo.Modules.RolesModule
{
    public class RolesPackage : IPackage
    {
        public RolesPackage()
        {

        }
        public void RegisterServices(Container container)
        {
            container.Register(typeof(IRequestHandler<,>), GetAssemblies());

            // we have to do this because by default, generic type definitions (such as the Constrained Notification Handler) won't be registered
            var notificationHandlerTypes = container.GetTypesToRegister(typeof(INotificationHandler<>),
                GetAssemblies(), new TypesToRegisterOptions
                {
                    IncludeGenericTypeDefinitions = true,
                    IncludeComposites = false,
                });
            container.Register(typeof(INotificationHandler<>), notificationHandlerTypes);

            container.Register(typeof(IPipelineBehavior<,>), Enumerable.Empty<Type>());
            container.Register(typeof(IRequestPreProcessor<>), Enumerable.Empty<Type>());
            container.Register(typeof(IRequestPostProcessor<,>), Enumerable.Empty<Type>());


            container.Register<IRolesRepository, RolesRepository>();
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(RolesPackage).GetTypeInfo().Assembly;
        }
    }
}
