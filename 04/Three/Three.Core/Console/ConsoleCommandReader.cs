using System;

namespace Three.Core
{
    public class ConsoleCommandReader : IReadCommands
    {
        public string Read()
        {
            return Console.ReadLine() ?? "";
        }
    }
}
