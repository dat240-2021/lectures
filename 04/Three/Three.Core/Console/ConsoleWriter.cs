using System;

namespace Three.Core
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string output)
        {
            Console.WriteLine(output);
        }
    }
}
