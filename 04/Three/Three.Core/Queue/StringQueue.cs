using System.Collections.Generic;

namespace Three
{
    public interface IStringQueue
    {
        int Length { get; }
        void Enqueue(string value);
        string Dequeue();
    }

    public class StringQueue : IStringQueue
    {
        private readonly Queue<string> _queue;

        public StringQueue()
        {
            _queue = new Queue<string>();
        }

        public int Length => _queue.Count;

        public string Dequeue()
        {
            return _queue.Dequeue();
        }

        public void Enqueue(string value)
        {
            _queue.Enqueue(value);
        }
    }
}