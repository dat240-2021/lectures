namespace Three.Core
{
    public class SizeCommand : ICommand
    {
        public bool Run()
        {
            System.Console.WriteLine("Size was called");
            return true;
        }
    }
}
