namespace Three.Core
{
    public class ExitCommand : ICommand
    {
        public bool Run()
        {
            System.Console.WriteLine("Exit was called");
            return false;
        }
    }
}
