namespace Three.Core
{
    public class AddCommand : ICommand
    {
        public bool Run()
        {
            System.Console.WriteLine("Add was called");
            return true;
        }
    }
}
