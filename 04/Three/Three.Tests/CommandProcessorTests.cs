using System;
using Xunit;
using Three.Core;
using Shouldly;
using System.Collections.Generic;

namespace Three.Tests
{
    public class CommandProcessorTests
    {
        [Fact]
        public void CommandStart_ShouldReadCommand()
        {
            var commands = new Dictionary<string, ICommand>
            {
                ["exit"] = new FakeExitCommand()
            };
            var fakeReader = new FakeExitCommandReader();
            var commandProcessor = new CommandProcessor(fakeReader, commands);

            commandProcessor.Start();

            fakeReader.WasCalled.ShouldBe(true);
        }

        [Fact]
        public void CommandStart_GivenExitCommand_ShouldCallExitCommand()
        {
            var commands = new Dictionary<string, ICommand>
            {
                ["exit"] = new FakeExitCommand()
            };
            var fakeReader = new FakeExitCommandReader();
            var commandProcessor = new CommandProcessor(fakeReader, commands);

            commandProcessor.Start();

            ((FakeExitCommand)commands["exit"]).WasCalled.ShouldBe(true);
        }

        [Fact]
        public void CommandStart_GivenCommandReturningFalse_ShouldTerminate()
        {
            var commands = new Dictionary<string, ICommand>
            {
                ["exit"] = new FakeExitCommand(),
                ["continue"] = new FakeContinueCommand()
            };
            var fakeReader = new FakeCommandReader(new string[] { "exit", "continue" });
            var commandProcessor = new CommandProcessor(fakeReader, commands);

            commandProcessor.Start();

            ((FakeExitCommand)commands["exit"]).WasCalled.ShouldBe(true);
            ((FakeContinueCommand)commands["continue"]).WasCalled.ShouldBe(false);
        }

        [Fact]
        public void CommandStart_GivenCommandReturningTrue_ShouldContinue()
        {
            var commands = new Dictionary<string, ICommand>
            {
                ["exit"] = new FakeExitCommand(),
                ["continue"] = new FakeContinueCommand()
            };
            var fakeReader = new FakeCommandReader(new string[] { "continue", "exit" });
            var commandProcessor = new CommandProcessor(fakeReader, commands);

            commandProcessor.Start();

            ((FakeContinueCommand)commands["continue"]).WasCalled.ShouldBe(true);
            ((FakeExitCommand)commands["exit"]).WasCalled.ShouldBe(true);
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
