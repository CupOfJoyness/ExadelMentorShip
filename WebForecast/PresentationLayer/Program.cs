using Autofac;
using BusinessLayer;
using System;
using BusinessLayer.Services;

namespace PresentationLayer
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<PresentationLayerDI>();
            Container = builder.Build();

            var viewer = new WeatherForecastViewer(Container.Resolve<IWeatherService>());

            viewer.ShowWeatherForNow();

            Console.ReadLine();
        }
    }
}