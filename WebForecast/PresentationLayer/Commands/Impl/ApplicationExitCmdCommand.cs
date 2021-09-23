using System;

namespace PresentationLayer.Commands.Impl
{
    public class ApplicationExitCmdCommand : BaseCmdCommand
    {
        protected override string CommandPattern => "0";
        public override string CommandMessage => "0.Exit.";

        protected override void Execute()
        {
            Environment.Exit(0);
        }
    }
}