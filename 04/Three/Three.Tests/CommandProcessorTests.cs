using System;
using Xunit;
using Three.Core;
using Shouldly;
using System.Collections.Generic;
using Moq;

namespace Three.Tests
{
    public class CommandProcessorTests
    {
        [Fact]
        public void CommandStart_ShouldReadCommand()
        {
            var exitCommand = new Mock<ICommand>();
            exitCommand.Setup(c => c.Run()).Returns(false);

            var commands = new Dictionary<string, ICommand>
            {
                ["exit"] = exitCommand.Object
            };
            var fakeReader = new FakeExitCommandReader();
            var commandProcessor = new CommandProcessor(fakeReader, commands);

            commandProcessor.Start();

            exitCommand.Verify(c => c.Run(), Times.Once);
        }

        [Fact]
        public void CommandStart_GivenExitCommand_ShouldCallExitCommand()
        {
            var exitCommand = new Mock<ICommand>();
            exitCommand.Setup(c => c.Run()).Returns(false);

            var commands = new Dictionary<string, ICommand>
            {
                ["exit"] = exitCommand.Object
            };
            var fakeReader = new FakeExitCommandReader();
            var commandProcessor = new CommandProcessor(fakeReader, commands);

            commandProcessor.Start();

            exitCommand.Verify(c => c.Run(), Times.Once);
        }
        [Fact]
        public void CommandStart_GivenCommandReturningFalse_ShouldTerminate()
        {
            var exitCommand = new Mock<ICommand>();
            exitCommand.Setup(c => c.Run()).Returns(false);
            var continueCommand = new Mock<ICommand>();
            continueCommand.Setup(c => c.Run()).Returns(true);

            var commands = new Dictionary<string, ICommand>
            {
                ["exit"] = exitCommand.Object,
                ["continue"] = continueCommand.Object
            };
            var fakeReader = new FakeCommandReader(new string[] { "exit", "continue" });
            var commandProcessor = new CommandProcessor(fakeReader, commands);

            commandProcessor.Start();

            exitCommand.Verify(c => c.Run(), Times.Once);
            continueCommand.Verify(c => c.Run(), Times.Never);
        }

        [Fact]
        public void CommandStart_GivenCommandReturningTrue_ShouldContinue()
        {
            var exitCommand = new Mock<ICommand>();
            exitCommand.Setup(c => c.Run()).Returns(false);
            var continueCommand = new Mock<ICommand>();
            continueCommand.Setup(c => c.Run()).Returns(true);

            var commands = new Dictionary<string, ICommand>
            {
                ["exit"] = exitCommand.Object,
                ["continue"] = continueCommand.Object
            };

            var fakeReader = new FakeCommandReader(new string[] { "continue", "exit" });
            var commandProcessor = new CommandProcessor(fakeReader, commands);

            commandProcessor.Start();

            exitCommand.Verify(c => c.Run(), Times.Once);
            continueCommand.Verify(c => c.Run(), Times.Once);
        }
    }

    public class FakeExitCommand : ICommand
    {
        public bool WasCalled { get; private set; }

        public bool Run()
        {
            WasCalled = true;
            return false;
        }
    }

    public class FakeContinueCommand : ICommand
    {
        public bool WasCalled { get; private set; }

        public bool Run()
        {
            WasCalled = true;
            return true;
        }
    }

    public class FakeExitCommandReader : IReadCommands
    {
        public bool WasCalled { get; private set; }

        public string Read()
        {
            WasCalled = true;
            return "exit";
        }
    }

    public class FakeCommandReader : IReadCommands
    {
        private readonly string[] _commands;
        private int _index;

        public FakeCommandReader(string[] commands)
        {
            _commands = commands;
        }

        public string Read()
        {
            return _commands[_index++];
        }
    }
}
