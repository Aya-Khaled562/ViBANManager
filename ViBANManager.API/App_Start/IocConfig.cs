using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using System;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using ViBANManager.API.Interfaces;
using ViBANManager.API.Services;
using ViBANManager.Infrastructure.Context;
using ViBANManager.Infrastructure.Repositories;

namespace ViBANManager.API.App_Start
{
    public class IocConfig
    {
        public static void RegisterServices()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Automatically register all profiles in the current assembly
            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
            }))
           .AsSelf()
           .SingleInstance();

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();


            // Register other services
            builder.RegisterType<ViBANDbContext>()
                   .AsSelf()
                   .InstancePerRequest();

            builder.RegisterType<BankConfigurationRepository>()
                   .As<IBankConfigurationRepository>()
                   .InstancePerRequest();

            builder.RegisterType<BankServiceFactory>()
                .As<IBankServiceFactory>()
                .InstancePerRequest();

            builder.Register(c => new HttpClient())
              .As<HttpClient>()
              .SingleInstance();

            // Build the container
            var container = builder.Build();

            // Set the dependency resolver
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

        }
    }
}