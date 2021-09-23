using Autofac;
using PresentationLayer.Apps;
using PresentationLayer.Viewers;
using PresentationLayer.Commands;
using PresentationLayer.Commands.Impl;

namespace PresentationLayer.DI
{
    public class CmdDI : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GetWeatherForNowCmdCommand>().As<ICmdCommand>();
            builder.RegisterType<GetForecastCmdCommand>().As<ICmdCommand>();
            builder.RegisterType<GetHottestCityCmdCommand>().As<ICmdCommand>();
            builder.RegisterType<ApplicationExitCmdCommand>().As<ICmdCommand>();

            builder.RegisterType<CmdApplication>().As<ICmdApplication>();
            builder.RegisterType<CommandsHandler>().As<ICommandsHandler>();
            builder.RegisterType<CmdWeatherForecastViewer>().As<IWeatherForecastViewer>();

            base.Load(builder);
        }
    }
}