using System;
using System.Threading.Tasks;

namespace PresentationLayer.Commands.Impl
{
    public abstract class BaseCmdCommand : ICmdCommand
    {
        public abstract string CommandMessange { get; }
        protected abstract string CommandPattern { get; }

        public void Execute(string commandLine)
        {
            if (string.IsNullOrWhiteSpace(commandLine)) throw new ArgumentException("Empty input.");

            Execute();
        }

        public bool CanExecute(string commandLine)
        {
            if (string.IsNullOrWhiteSpace(commandLine)) throw new ArgumentException(nameof(commandLine));

            return commandLine == CommandPattern;
        }

        protected abstract void Execute();
    }
}