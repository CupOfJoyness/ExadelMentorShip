using Autofac;
using AutoMapper;
using BusinessLayer;
using PresentationLayer.Mappings;
using System.Collections.Generic;

namespace PresentationLayer.DI
{
    public class PresentationLayerDI : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<BusinessLayerDI>();

            builder.Register(ctx => PresentationMapperConfiguration.GetMapperCongiguration().CreateMapper())
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}