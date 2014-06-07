using System;
using Zulu.Threading.ThreadPools.TaskItems;

namespace Zulu.Threading.ThreadPools
{
    public interface IExtendedThreadPool
    {
        /// <summary>
        /// MaxThreads per processor.
        /// </summary>
        int MaxThreads { get; }

        /// <summary>
        /// MinThreads per processor.
        /// </summary>
        int MinThreads { get; }

        /// <summary>
        /// Represents threading capacity
        /// </summary>
        MultiThreadingCapacityType MultiThreadingCapacityType { get; }

        /// <summary>
        /// Thread pool name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Add new task.
        /// </summary>
        /// <param name="taskItem">Represent task.</param>
        /// <param name="priority">Task priority.</param>
        /// <remarks>Default task priority is <see cref="TaskItemPriority.Normal" />.</remarks>
        void AddTask(ITaskItem taskItem, TaskItemPriority priority = TaskItemPriority.Normal);

        /// <summary>
        /// Add new task as <see cref="Action" />.
        /// </summary>
        /// <param name="action">Represent task.</param>
        /// <param name="priority">Task priority.</param>
        /// <remarks>Default task priority is <see cref="TaskItemPriority.Normal" />.</remarks>
        void AddTask(Action action, TaskItemPriority priority = TaskItemPriority.Normal);

        /// <summary>
        /// Stop the ThreadPool.
        /// </summary>
        void Stop();
    }
}
