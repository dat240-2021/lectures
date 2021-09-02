namespace Three.Core
{
    public interface ICommand
    {
        /// <summary>
        /// Runs the command
        /// </summary>
        /// <returns>False if the command signals a termination of the program, true if not</returns>
        bool Run();
    }
}