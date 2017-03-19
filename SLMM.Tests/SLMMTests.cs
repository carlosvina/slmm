using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace SLMM.Tests
{
    [TestFixture]
    public class SLMMTests
    {

        private TestConsole _console;
        private Garden _garden;
        private IMowingMachine _slmm;
        private List<ConsoleKeyInfo> keys;
        private List<Command> commandList;

        [SetUp]
        public void Init()
        {
            _console = new TestConsole();
            keys = new List<ConsoleKeyInfo>()
            {
                new ConsoleKeyInfo('\0', ConsoleKey.DownArrow, false, false, false)
            };
            _console.keys = keys;

            _garden = new Garden(5, 5, _console);
            _slmm = new MowingMachine(_garden, _console);
        }

        [TearDown]
        public void Cleanup()
        {
            _console = null;
            _garden = null;
            _slmm = null;
            keys = null;
        }

        [TestCase(0)]
        [TestCase(1)]
        public void SLMM_StaysIn_Boundaries(int test)
        {
            commandList = new List<Command>();
            if (test == 0) 
            {
                commandList.Add(Command.TurnLeft);  // face east
                
            }
            else
            {
                commandList.Add(Command.TurnLeft);
                commandList.Add(Command.TurnLeft);  // face south
            }
            commandList.Add(Command.Move);
            commandList.Add(Command.Stop);

            foreach (var command in commandList)
            {
                _slmm.PushCommand(command);
            }

            _slmm.Start();

            var position = _slmm.GetPosition;

            Assert.AreEqual(position["width"], 0);
            Assert.AreEqual(position["length"], 0);
        }

        [Test]
        public void SLMM_Position_Correct()
        {
            commandList = new List<Command>()
            {
                Command.Move, Command.TurnRight, Command.Move, Command.Mown,
                Command.Move, Command.TurnLeft, Command.Move, Command.Stop
            };

            foreach (var command in commandList)
            {
                _slmm.PushCommand(command);
            }

            _slmm.Start();

            var position = _slmm.GetPosition;

            Assert.AreEqual(position["width"], 2);
            Assert.AreEqual(position["length"], 2);
        }
    }
}
