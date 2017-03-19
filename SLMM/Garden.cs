using System;
using System.Threading;

namespace SLMM
{
    public class Garden
    {
        private int _width;
        private int _length;
        private IMowingMachine _slmm;
        private IConsole _console;

        public Garden(int width, int length, IConsole console)
        {
            _width = width;
            _length = length;
            _slmm = new MowingMachine(this, console);
            _console = console;
        }

        public void Run()
        {
            bool stop = false;
            Thread thread = new Thread(new ThreadStart(StartSLMM));
            thread.Start();
            while (!stop)
            {
                ConsoleKeyInfo command = _console.ReadKey(true);
                switch (command.Key)
                {
                    case ConsoleKey.UpArrow:
                        _slmm.PushCommand(Command.Move);
                        break;
                    case ConsoleKey.LeftArrow:
                        _slmm.PushCommand(Command.TurnLeft);
                        break;
                    case ConsoleKey.RightArrow:
                        _slmm.PushCommand(Command.TurnRight);
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.M:
                        _slmm.PushCommand(Command.Mown);
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.Escape:
                        _slmm.PushCommand(Command.Stop);
                        stop = true;
                        break;
                }                
            }

            _console.WriteLine("STOP command received. No more commands allowed to be entered.");
        }

        public void StartSLMM()
        {
            _slmm.Start();            
        }

        public int Width
        {
            get
            {
                return _width;
            }
        }

        public int Length
        {
            get
            {
                return _length;
            }
        }


    }
}
