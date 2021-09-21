using Autofac;
using DataLayer.DI;
using BusinessLayer.Services;
using Module = Autofac.Module;

namespace BusinessLayer.DI
{
    public class BusinessLayerDI : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<DataLayerDI>();
            builder.RegisterType<WeatherService>().As<IWeatherService>();
        }
    }
}