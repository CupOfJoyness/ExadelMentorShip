using Autofac;
using DataLayer.Repositories;
using Module = Autofac.Module;

namespace DataLayer.DI
{
    public class DataLayerDI : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WeatherRepository>().As<IWeatherRepository>();
        }
    }
}