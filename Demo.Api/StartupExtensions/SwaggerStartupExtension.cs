using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Demo.StartupExtensions
{
    internal static class SwaggerStartupExtension
    {
        internal static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Mediator Pattern Demo",
                    Version = "v1",
                    Description = "An API to demonstrate the Mediator Pattern combined with CQRS",
                });
            });

            return services;
        }
        internal static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mediator Pattern Demo");
                c.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}
