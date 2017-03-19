using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace SLMM.Tests
{
    [TestFixture]
    public class GardenTests
    {

        private TestConsole _console;
        private Garden _garden;
        private IMowingMachine _slmm;
        private List<ConsoleKeyInfo> keys;

        [SetUp]
        public void Init()
        {
            _console = new TestConsole();
            keys = new List<ConsoleKeyInfo>()
            {
                new ConsoleKeyInfo('\0', ConsoleKey.UpArrow, false, false, false),
                new ConsoleKeyInfo('\0', ConsoleKey.RightArrow, false, false, false),
                new ConsoleKeyInfo('\0', ConsoleKey.UpArrow, false, false, false),
                new ConsoleKeyInfo('\0', ConsoleKey.LeftArrow, false, false, false),
                new ConsoleKeyInfo('\0', ConsoleKey.LeftArrow, false, false, false),
                new ConsoleKeyInfo('\0', ConsoleKey.UpArrow, false, false, false),
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

        [Test]
        public void Garden_Run_OK()
        {
            Assert.DoesNotThrow(_garden.Run);
        }
    }
}
