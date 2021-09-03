namespace Three.Core
{
    public class RemCommand : ICommand
    {
        public bool Run()
        {
            System.Console.WriteLine("Rem was called");
            return true;
        }
    }
}
