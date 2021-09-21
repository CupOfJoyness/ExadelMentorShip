using Autofac;
using PresentationLayer.DI;
using PresentationLayer.Apps;

namespace PresentationLayer
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<DIConfiguration>();
            Container = builder.Build();

            var cmdApplication = Container.Resolve<ICmdApplication>();

            while (true)
            {
                cmdApplication.Run(args);
            }
        }
    }
}