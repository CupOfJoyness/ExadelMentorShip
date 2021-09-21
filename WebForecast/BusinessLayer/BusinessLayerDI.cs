using Autofac;
using BusinessLayer.Services;
using DataLayer;
using Module = Autofac.Module;

namespace BusinessLayer
{
    public class BusinessDI : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<DataLayerDI>();
            builder.RegisterType<WeatherService>().As<IWeatherService>();
        }
    }
}