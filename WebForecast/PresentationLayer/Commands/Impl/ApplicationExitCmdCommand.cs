using System;
using System.Threading.Tasks;

namespace PresentationLayer.Commands.Impl
{
    public class ApplicationExitCmdCommand : BaseCmdCommand
    {
        protected override string CommandPattern => "3";
        public override string CommandMessange => "3.Exit.";

        protected override void Execute()
        {
            Environment.Exit(0);
        }
    }
}