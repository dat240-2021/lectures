using System;
using System.Collections.Generic;

namespace Three.Core
{
    public class CommandProcessor
    {
        private readonly IReadCommands _commandReader;
        private readonly Dictionary<string, ICommand> _commands;

        public CommandProcessor(IReadCommands commandReader,
                                Dictionary<string, ICommand> commands)
        {
            _commandReader = commandReader;
            _commands = commands;
        }

        public void Start()
        {
            string command;
            do
            {
                command = _commandReader.Read();
            }
            while (_commands[command].Run());

        }
    }
}