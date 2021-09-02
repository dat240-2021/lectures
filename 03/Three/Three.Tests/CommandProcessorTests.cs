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
            var commands = new Dictionary<string, ICommands>();
            commands["exit"] = new FakeExitCommand();
            var fakeReader = new FakeExitCommandReader();
            var commandProcessor = new CommandProcessor(fakeReader, commands);

            commandProcessor.Start();

            fakeReader.WasCalled.ShouldBe(true);
        }

        [Fact]
        public void CommandStart_GivenExitCommand_ShouldCallExitCommand()
        {
            var commands = new Dictionary<string, ICommands>();
            commands["exit"] = new FakeExitCommand() as ICommands;
            var fakeReader = new FakeExitCommandReader();
            var commandProcessor = new CommandProcessor(fakeReader, commands);

            commandProcessor.Start();

            ((FakeExitCommand)commands["exit"]).WasCalled.ShouldBe(true);
        }
    }

    public class FakeExitCommand 
    {
        public bool WasCalled{ get; private set;}

        public void Run()
        {
            WasCalled = true;
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
}
