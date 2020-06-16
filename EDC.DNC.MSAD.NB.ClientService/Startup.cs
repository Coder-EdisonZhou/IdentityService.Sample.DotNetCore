using AspectCore.Extensions.DependencyInjection;
using EasyNetQ;
using Exceptionless;
using EDC.DNC.MSAD.Common;
using EDC.DNC.MSAD.Common.Logging;
using EDC.DNC.MSAD.NB.ClientService.Models;
using EDC.DNC.MSAD.NB.ClientService.Repositories;
using EDC.DNC.MSAD.NB.ClientService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EDC.DNC.MSAD.NB.ClientService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // IoC - EventBus
            //services.AddSingleton(RabbitHutch.CreateBus(Configuration["MQ:Dev"]));
            // IoC - Logger
            services.AddSingleton<ILogger, ExceptionlessLogger>();
            // IoC - Service & Repository
            services.AddScoped<IClientService, EDC.DNC.MSAD.NB.ClientService.Services.ClientService>();
            services.AddScoped<IClientRepository, ClientRepository>();
            // IoC - DbContext
            services.AddDbContextPool<ClientDbContext>(
                options => options.UseSqlServer(Configuration["DB:Dev"]));

            services.AddMvc();

            // IdentityServer
            services.AddAuthentication(Configuration["IdentityService:DefaultScheme"])
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Configuration["IdentityService:Uri"];
                    options.RequireHttpsMetadata = Convert.ToBoolean(Configuration["IdentityService:UseHttps"]);
                });

            // Tracing - Butterfly
            //services.AddButterfly(option =>
            //{
            //    option.CollectorUrl = Configuration["TracingCenter:Uri"];
            //    option.Service = Configuration["TracingCenter:Name"];
            //});
            //services.AddSingleton<HttpClient>(p => new HttpClient(p.GetService<HttpTracingHandler>()));

            // Swagger
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc(Configuration["Service:DocName"], new Info
                {
                    Title = Configuration["Service:Title"],
                    Version = Configuration["Service:Version"],
                    Description = Configuration["Service:Description"],
                    Contact = new Contact
                    {
                        Name = Configuration["Service:Contact:Name"],
                        Email = Configuration["Service:Contact:Email"]
                    }
                });

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, Configuration["Service:XmlFile"]);
                s.IncludeXmlComments(xmlPath);
            });
            // AoP - AspectCore
            RegisterServices(this.GetType().Assembly, services);
            services.AddDynamicProxy();

            return services.BuildAspectCoreServiceProvider();
        }

        private static void RegisterServices(Assembly asm, IServiceCollection services)
        {
            foreach (var type in asm.GetExportedTypes())
            {
                bool hasHystrixCommand = type.GetMethods().Any(m =>
                    m.GetCustomAttribute(typeof(HystrixCommandAttribute)) != null);
                if (hasHystrixCommand)
                {
                    services.AddSingleton(type);
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            // exceptionless
            app.UseExceptionless(Configuration["Exceptionless:ApiKey"]);
            // swagger
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "doc/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint($"/doc/{Configuration["Service:DocName"]}/swagger.json",
                    $"{Configuration["Service:Name"]} {Configuration["Service:Version"]}");
            });
            // IdentityServer
            app.UseAuthentication();
        }
    }
}
