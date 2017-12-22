using System.Reflection;
using AglCodingTestNew.Mappers;
using AglCodingTestNew.Queries;
using AglCodingTestNew.ResultFilters;
using Autofac;
using Module = Autofac.Module;
using System.Configuration;
using AglCodingTestNew.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AglCodingTestNew
{
    public class AutofacModule : Module
    {
        private readonly Settings.Settings _settings;

        public AutofacModule(Settings.Settings config)
        {
            _settings = config;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = new[] {Assembly.GetExecutingAssembly()};

            builder
                .RegisterAssemblyTypes(assemblies)
                .AsClosedTypesOf(typeof(IQuery<,>));

            builder
                .RegisterAssemblyTypes(assemblies)
                .AsClosedTypesOf(typeof(IMapper<,>));

            builder
                .RegisterAssemblyTypes(assemblies)
                .AsClosedTypesOf(typeof(IResultFilter<>));

            builder.RegisterInstance(_settings).AsImplementedInterfaces();
        }
    }
}