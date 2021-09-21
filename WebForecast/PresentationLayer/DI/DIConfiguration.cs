using Autofac;
using AutoMapper;
using BusinessLayer.DI;
using PresentationLayer.Mappings;

namespace PresentationLayer.DI
{
    public class DIConfiguration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CmdDI>();
            builder.RegisterModule<BusinessLayerDI>();

            builder.Register(ctx => MappingConfiguration.GetMapperCongiguration().CreateMapper())
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}