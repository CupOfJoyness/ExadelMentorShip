using Autofac;
using BusinessLayer;

namespace PresentationLayer
{
    public class PresentationLayerDI : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<BusinessDI>();
        }
    }
}
