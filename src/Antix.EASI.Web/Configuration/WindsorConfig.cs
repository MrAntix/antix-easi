using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Filters;
using Antix.Data.Keywords;
using Antix.Data.Keywords.EF;
using Antix.Data.Keywords.Processing;
using Antix.Data.Projections;
using Antix.EASI.Api;
using Antix.EASI.Application.People.Examiners;
using Antix.EASI.Data.EF;
using Antix.EASI.Data.EF.People.Examiners.Models;
using Antix.EASI.Data.EF.People.Patients.Models;
using Antix.EASI.Domain.Validation;
using Antix.Http.Dispatcher;
using Antix.Http.Filters;
using Antix.Http.Filters.Logging;
using Antix.Http.Services.Filters;
using Antix.Logging;
using Antix.Services;
using Antix.Services.Validation;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Newtonsoft.Json.Converters;

namespace Antix.EASI.Web.Configuration
{
    public static class WindsorConfig
    {
        static readonly Assembly CoreAssembly = typeof (Log).Assembly;
        static readonly Assembly DomainAssembly = typeof (DomainValidationPredicates).Assembly;
        static readonly Assembly ApplicationAssembly = typeof (CreateExaminerService).Assembly;
        static readonly Assembly DataAssembly = typeof (DataContext).Assembly;
        static readonly Assembly ApiAssembly = typeof (ApiRoutes).Assembly;
        static readonly Assembly PortalAssembly = typeof (Global).Assembly;

        public static IWindsorContainer Init(
            IWindsorContainer container,
            HttpConfiguration configuration)
        {
            container.AddFacility<TypedFactoryFacility>();

            var log = RegisterLogging(container);

            RegisterServices(container);
            RegisterData(container);

            RegisterWebApi(container, configuration, log);

            RegisterKeywordIndexing(container);

            log.Information(m => m("Application Configured"));

            return container;
        }

        static void RegisterKeywordIndexing(IWindsorContainer container)
        {
            container.Register(
                Component.For<IKeywordProcessor>()
                    .Instance(WordSplitKeywordProcessor.Create())
                    .LifestyleSingleton()
                );
            container.Register(
                Component.For<IKeywordsBuilderProvider, KeywordsBuilderProvider>()
                    .LifestyleSingleton()
                );
            container.Register(
                Component.For<IKeywordsIndexer, EFKeywordsManager>()
                    .LifestyleSingleton()
                );
        }

        static Log.Delegate RegisterLogging(IWindsorContainer container)
        {
            var log = Log.ToTrace;

            container.Register(
                Component.For<Log.Delegate>()
                    .Instance(log)
                    .LifestyleSingleton()
                );

            return log;
        }

        static void RegisterData(IWindsorContainer container)
        {
            container.Register(
                Classes.FromAssembly(DataAssembly)
                    .BasedOn<IProjection>()
                    .WithServiceAllInterfaces()
                    .LifestyleSingleton()
                );
            container.Register(
                Component
                    .For<IProjectionProvider, ProjectionProvider>()
                    .LifestyleSingleton()
                );
            container.Register(
                Component
                    .For<IEnumerable<IProjection>>()
                    .UsingFactoryMethod(k => k.ResolveAll<IProjection>())
                    .LifestyleSingleton()
                );

            container.Register(
                Component
                    .For<DataContext, DataContext>()
                    .LifestylePerWebRequest()
                );
        }

        static void RegisterServices(
            IWindsorContainer container)
        {
            container.Register(
                Component.For(typeof (IValidationRuleBuilder<>))
                    .ImplementedBy(typeof (ValidationRuleBuilder<>))
                    .LifestyleTransient()
                );
            container.Register(
                Classes.FromAssembly(DomainAssembly)
                    .BasedOn<IService>()
                    .WithServiceAllInterfaces()
                    .WithServiceSelf()
                    .LifestyleTransient()
                );
            container.Register(
                Classes.FromAssembly(ApplicationAssembly)
                    .BasedOn<IService>()
                    .WithServiceAllInterfaces()
                    .WithServiceSelf()
                    .LifestyleTransient()
                );
            container.Register(
                Classes.FromAssembly(DataAssembly)
                    .BasedOn<IService>()
                    .WithServiceAllInterfaces()
                    .WithServiceSelf()
                    .LifestyleTransient()
                );
            container.Register(
                Classes.FromAssembly(ApiAssembly)
                    .BasedOn<IService>()
                    .WithServiceAllInterfaces()
                    .WithServiceSelf()
                    .LifestyleTransient()
                );
        }

        static void RegisterWebApi(
            IWindsorContainer container,
            HttpConfiguration configuration,
            Log.Delegate log)
        {
            container.Register(
                Classes.FromAssembly(ApiAssembly)
                    .BasedOn<ApiController>()
                    .LifestyleTransient()
                );
            container.Register(
                Classes.FromAssembly(PortalAssembly)
                    .BasedOn<IFilter>()
                    .WithServiceSelf()
                    .LifestyleTransient()
                );
            container.Register(
                Classes.FromAssembly(CoreAssembly)
                    .BasedOn<IFilter>()
                    .WithServiceSelf()
                    .LifestyleTransient()
                );

            configuration.Services.Replace(
                typeof (IHttpControllerActivator),
                new ServiceHttpControllerActivator(
                    t => (IHttpController) container.Resolve(t),
                    container.Release,
                    log
                    )
                );

            configuration.Services.Replace(
                typeof (IFilterProvider),
                new ServiceFilterProvider(container.Resolve)
                );

            configuration.Filters.Add(
                container.Resolve<LogActionFilter>());
            configuration.Filters.Add(
                container.Resolve<ServiceResponseGlobalFilter>());

            configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            configuration.MapHttpAttributeRoutes();

            var formatter = configuration.Formatters.JsonFormatter;
            formatter.SerializerSettings.ContractResolver
                = new SpecialCamelCasePropertyNamesContractResolver();

            configuration.Formatters.JsonFormatter.SerializerSettings.Converters.Add(
                new IsoDateTimeConverter
                {
                    DateTimeFormat = "yyyy-MM-ddTHH:mmZ"
                });

            configuration.Formatters.Clear();
            configuration.Formatters.Add(formatter);

            configuration.EnsureInitialized();
        }
    }
}