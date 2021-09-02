using System.Collections.Generic;

namespace Three.Core
{
    public static class Program
    {
        public static void Main()
        {
            var commands = new Dictionary<string, ICommand>
            {
                ["exit"] = new ExitCommand(),
                ["add"] = new AddCommand(),
                ["rem"] = new RemCommand(),
            };

            var commandProcessor = new CommandProcessor(new ConsoleCommandReader(), commands);
            commandProcessor.Start();
        }
    }
}
