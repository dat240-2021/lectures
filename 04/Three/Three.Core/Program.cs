using System;
using System.Collections.Generic;
using System.Linq;

namespace Three.Core
{
    public static class Program
    {
        public static void Main()
        {
            var commands = new Dictionary<string, ICommand>();

            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes())
                .Where(t => typeof(ICommand).IsAssignableFrom(t) && !t.IsInterface)
                .ToList();

            foreach(var type in types) {
                ICommand? command = Activator.CreateInstance(type) as ICommand;
                if (command is not null) {
                    commands.Add(
                        type.Name.Replace("Command", "").ToLower(),
                        command
                    );
                }
            }
            // {
            //     ["exit"] = new ExitCommand(),
            //     ["add"] = new AddCommand(),
            //     ["rem"] = new RemCommand(),
            // };

            var commandProcessor = new CommandProcessor(new ConsoleCommandReader(), commands);
            commandProcessor.Start();
        }
    }
}
