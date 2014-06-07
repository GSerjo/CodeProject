using System.Collections.Generic;
using Zulu.Threading.ThreadPools.TaskItems;

namespace Zulu.Threading.ThreadPools.TaskQueues
{
    /// <summary>
    /// Represent default task queue, does not validate TaskItemPriority
    /// </summary>
    public sealed class DefaultTaskQueue : ITaskQueue
    {
        private readonly Queue<IWorkItem> _queue = new Queue<IWorkItem>();

        /// <summary>
        /// Count of work item.
        /// </summary>
        public int Count
        {
            get { return _queue.Count; }
        }

        /// <summary>
        /// Dequeue the work item.
        /// </summary>
        /// <returns>The work item.</returns>
        public IWorkItem Dequeue()
        {
            return _queue.Dequeue();
        }

        /// <summary>
        /// Enqueue the work item.
        /// </summary>
        /// <param name="item">The work item.</param>
        public void Enqueue(IWorkItem item)
        {
            _queue.Enqueue(item);
        }
    }
}
