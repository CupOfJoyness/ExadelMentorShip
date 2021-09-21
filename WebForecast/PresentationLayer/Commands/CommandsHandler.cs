using System;
using System.Linq;
using System.Collections.Generic;
using PresentationLayer.Exceptions;

namespace PresentationLayer.Commands
{
    public class CommandsHandler : ICommandsHandler
    {
        private readonly IEnumerable<ICmdCommand> _cmdCommands;

        public CommandsHandler(IEnumerable<ICmdCommand> commands)
        {
            _cmdCommands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        public void Handle(string commandLine)
        {
            if (string.IsNullOrWhiteSpace(commandLine)) throw new ArgumentException("Empty input.");

            var command = _cmdCommands.FirstOrDefault(cmdCommand => cmdCommand.CanExecute(commandLine)) ??
                          throw new CommandNotFoundException();
            command.Execute(commandLine);
        }
    }
}