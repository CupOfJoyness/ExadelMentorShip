using System;
using Autofac;
using PresentationLayer.DI;
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

            viewer.Run();

            Console.ReadLine();
        }
    }
}