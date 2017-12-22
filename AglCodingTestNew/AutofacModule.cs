using System;
using System.Reflection;
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
            builder
                .RegisterAssemblyTypes(new [] {Assembly.GetExecutingAssembly()})
                .AsClosedTypesOf(typeof(IQuery<,>));
        }
    }
}