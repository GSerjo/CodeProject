using Zulu.Threading.ThreadPools.TaskItems;

namespace Zulu.Threading.ThreadPools.TaskQueues
{
    /// <summary>
    /// Represent the queue.
    /// </summary>
    public interface ITaskQueue
    {
        /// <summary>
        /// Count of work item.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Dequeue the work item.
        /// </summary>
        /// <returns>The work item.</returns>
        IWorkItem Dequeue();

        /// <summary>
        /// Enqueue the work item.
        /// </summary>
        /// <param name="item">The work item.</param>
        void Enqueue(IWorkItem item);
    }
}
