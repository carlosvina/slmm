using System;

namespace SLMM
{
    public interface IConsole
    {
        void Write(string msg);
        void WriteLine(string msg);
        string ReadLine();
        ConsoleKeyInfo ReadKey(bool intercept);
    }
}
