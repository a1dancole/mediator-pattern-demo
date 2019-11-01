using Demo.Core.Database;
using Demo.Core.Infrastructure;
using Demo.StartupExtensions;
using FluentValidation;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleInjector;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Demo
{
    public class Startup
    {
        private readonly Container _container = new Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("MediatorDemo");

            services.AddMvcCore();
            services.AddControllers();
            services.AddSwaggerDocumentation();

            services.AddProblemDetails(exception =>
            {
                exception.Map<BusinessRuleValidationException>(ex =>
                    new BusinessRuleValidationExceptionProblemDetails(ex));

                exception.Map<ValidationException>(ex =>
                    new ValidationExceptionProblemDetails(ex));
            });

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        10,
                        TimeSpan.FromSeconds(30),
                        null
                    );
                });
                options.EnableSensitiveDataLogging(true);
            });

            services.AddSimpleInjector(_container, options =>
            {
                options.AddAspNetCore()
                    .AddControllerActivation();

                var assemblies =
                    from file in new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).GetFiles()
                    where file.Extension.ToLower() == ".dll" && file.FullName.Contains("Demo")
                    select Assembly.Load(AssemblyName.GetAssemblyName(file.FullName));

                _container.RegisterPackages(assemblies);

                _container.Register<DatabaseContext>(() =>
                {
                    var optionsBuilder =
                        new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer(connectionString, sqlOptions =>
                        {
                            sqlOptions.EnableRetryOnFailure(
                                10,
                                TimeSpan.FromSeconds(30),
                                null
                            );
                        });
                    return new DatabaseContext(optionsBuilder.Options);
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseProblemDetails();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.InitializeDatabase();

            app.UseSimpleInjector(_container, options => { });

            app.UseSwaggerDocumentation();
        }
    }
}
