﻿using System.Reflection;
using AglCodingTest.Core.Mappers;
using AglCodingTest.Core.Queries;
using AglCodingTest.Core.ResultFilters;
using Autofac;
using Module = Autofac.Module;

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
            var assemblies = new[] {Assembly.GetExecutingAssembly(), Assembly.GetAssembly(typeof(AglCodingTest.Core.Domain.Person)), };

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