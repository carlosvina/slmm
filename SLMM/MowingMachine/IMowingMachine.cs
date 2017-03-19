using System.Collections.Generic;

namespace SLMM
{
    public interface IMowingMachine
    {
        void Start();
        void Stop();
        void PushCommand(Command command);
        Dictionary<string, int> GetPosition { get; }
    }
}
