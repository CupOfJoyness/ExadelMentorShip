namespace PresentationLayer.Commands
{
    public interface ICommandsHandler
    {
        void Handle(string commandLine);
    }
}