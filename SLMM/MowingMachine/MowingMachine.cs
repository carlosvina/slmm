using System;
using System.Collections.Generic;
using System.Threading;

namespace SLMM
{
    public class MowingMachine : IMowingMachine
    {
        private Queue<Command> _commandQ;
        private Dictionary<string, int> _position;
        private Heading _heading;
        private Garden _garden;
        private IConsole _console;
        private bool _active;

        public MowingMachine(Garden garden, IConsole console)
        {
            _garden = garden;
            _console = console;
            _commandQ = new Queue<Command>();
            _position = new Dictionary<string, int> { { "width", 0 }, { "length", 0 } };
            _heading = Heading.North;
        }

        public void PushCommand(Command command)
        {
            _commandQ.Enqueue(command);
            _console.WriteLine($"Command {command} has been saved in the queue.");
        }

        public void Start()
        {
            _active = true;
            while (_active)
            {
                var command = ReadCommand();
                switch (command)
                {
                    case Command.TurnLeft:
                    case Command.TurnRight:
                        Thread.Sleep(10000);
                        Turn(command);
                        break;
                    case Command.Mown:
                        Thread.Sleep(120000);
                        break;
                    case Command.Move:
                        Move();
                        Thread.Sleep(15000);
                        break;
                    case Command.Stop:
                        Stop();                    
                        break;
                    case Command.DoNothing:
                        Thread.Sleep(1000);
                        break;
                }

                _console.WriteLine($"{DateTime.Now} – {command} – ({_position["width"]}, {_position["length"]})");

            }
        }

        public void Stop()
        {
            _active = false;
            _console.WriteLine("SLMM stopped. Please press any key to exit.");
            _console.ReadKey(true);
        }

        public Dictionary<string, int> GetPosition
        {
            get
            {
               return _position;
            }
        }

        private Command ReadCommand()
        {
            if (_commandQ.Count == 0) return Command.DoNothing;
            else return _commandQ.Dequeue();
        }

        // x = width, y = length 
        private bool Move()
        {
            switch (_heading)
            {
                case Heading.North:
                    _position["length"] = _position["length"] < _garden.Length ? ++_position["length"] : _position["length"];
                    break;
                case Heading.South:
                    _position["length"] = _position["length"] > 0 ? --_position["length"] : _position["length"];
                    break;
                case Heading.East:
                    _position["width"] = _position["width"] < _garden.Width ? ++_position["width"] : _position["width"];
                    break;
                case Heading.West:
                    _position["width"] = _position["width"] > 0 ? --_position["width"] : _position["width"];
                    break;
            }

            return false;
        }

        private void Turn(Command command)
        {
            switch(_heading)
            {
                case Heading.North:
                    _heading = command.Equals(Command.TurnLeft) ? Heading.West : Heading.East;
                    break;
                case Heading.South:
                    _heading = command.Equals(Command.TurnLeft) ? Heading.East : Heading.West;
                    break;
                case Heading.East:
                    _heading = command.Equals(Command.TurnLeft) ? Heading.North : Heading.South;
                    break;
                case Heading.West:
                    _heading = command.Equals(Command.TurnLeft) ? Heading.South : Heading.North;
                    break;
            }
        }
    }
}
