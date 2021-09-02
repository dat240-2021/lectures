using System;
using System.Collections.Generic;

namespace Three.Core
{
    public class CommandProcessor
    {
        private readonly IReadCommands commandReader;
        private readonly Dictionary<string, ICommands> commands;

        public CommandProcessor(IReadCommands commandReader,
                                Dictionary<string, ICommands> commands)
        {
            this.commandReader = commandReader;
            this.commands = commands;
        }

        public void Start()
        {
            var command = commandReader.Read();

            commands[command].Run();
            
        }
    }

    public interface IReadCommands {
        public string Read();
    }
}