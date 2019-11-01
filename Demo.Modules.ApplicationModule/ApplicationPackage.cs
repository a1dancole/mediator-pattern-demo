using MediatR;
using MediatR.Pipeline;
using SimpleInjector;
using SimpleInjector.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Container = SimpleInjector.Container;

namespace Demo.Modules.ApplicationModule
{
    public class ApplicationPackage : IPackage
    {
        public ApplicationPackage()
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


            container.Register<IApplicationRepository, ApplicationRepository>();
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(ApplicationPackage).GetTypeInfo().Assembly;
        }
    }
}
