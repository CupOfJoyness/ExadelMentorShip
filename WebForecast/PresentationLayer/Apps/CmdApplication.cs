using System;
using System.Collections.Generic;
using PresentationLayer.Commands;

namespace PresentationLayer.Apps
{
    public class CmdApplication : ICmdApplication
    {
        private readonly ICommandsHandler _commandsHandler;
        private readonly IEnumerable<ICmdCommand> _commands;

        public CmdApplication(ICommandsHandler commandsHandler, IEnumerable<ICmdCommand> commands)
        {
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
            _commandsHandler = commandsHandler ?? throw new ArgumentNullException(nameof(commandsHandler));
        }

        public void Run(string[] args)
        {
            Console.WriteLine("Choose forecast option:");
            try
            {
                foreach (var command in _commands)
                {
                    Console.WriteLine(command.CommandMessange);
                }

                Console.Write("> ");
                _commandsHandler.Handle(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}