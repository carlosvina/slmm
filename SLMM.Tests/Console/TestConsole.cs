using System;
using System.Collections.Generic;

namespace SLMM.Tests
{
    public class TestConsole : IConsole
    {
        public List<string> lines = new List<string>();
        public List<ConsoleKeyInfo> keys = new List<ConsoleKeyInfo>();

        public void Write(string msg)
        {
            Console.Write(msg);
        }

        public void WriteLine(string msg)
        {
            Console.WriteLine(msg);
        }

        public string ReadLine()
        {
            string result = lines[0];
            lines.RemoveAt(0);
            return result;
        }

        public ConsoleKeyInfo ReadKey(bool intercept)
        {
            ConsoleKeyInfo result = keys[0];
            keys.RemoveAt(0);
            return result;
        }
    }
}
