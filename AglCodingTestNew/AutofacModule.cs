using System;
using System.Reflection;
using AglCodingTestNew.Mappers;
using AglCodingTestNew.Queries;
using AglCodingTestNew.Queries.GetJson;
using Autofac;
using Autofac.Core;
using Module = Autofac.Module;

namespace AglCodingTestNew
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = new[] {Assembly.GetExecutingAssembly()};

            builder
                .RegisterAssemblyTypes(assemblies)
                .AsClosedTypesOf(typeof(IQuery<,>));

            builder
                .RegisterAssemblyTypes(assemblies)
                .AsClosedTypesOf(typeof(IMapper<,>));

        }
    }
}