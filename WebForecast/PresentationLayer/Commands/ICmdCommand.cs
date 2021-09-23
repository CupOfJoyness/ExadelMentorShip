namespace PresentationLayer.Commands
{
    public interface ICmdCommand
    {
        string CommandMessage { get; }
        void Execute(string commandLine);
        bool CanExecute(string commandLine);
    }
}