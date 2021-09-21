using System.Threading.Tasks;

namespace PresentationLayer.Commands
{
    public interface ICmdCommand
    {
        string CommandMessange { get; }
        void Execute(string commandLine);
        bool CanExecute(string commandLine);
    }
}