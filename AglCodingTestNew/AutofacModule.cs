using System;
using System.IO;
using System.Linq;
using System.Reflection;
using AglCodingTest.Core.Mappers;
using AglCodingTest.Core.Queries;
using AglCodingTest.Core.ResultFilters;
using Autofac;
using Module = Autofac.Module;

namespace AglCodingTest.Web
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
            var assemblies = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.TopDirectoryOnly)
                .Where(filePath => Path.GetFileName(filePath).StartsWith("AglCodingTest"))
                .Select(Assembly.LoadFrom)
                .ToArray();

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