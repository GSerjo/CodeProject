using System;
using Zulu.Threading.ThreadPools.TaskItems;

namespace Zulu.Threading.ThreadPools.TaskQueueControllers
{
    public interface ITaskQueueController : IDisposable
    {
        int ConsumersWaiting { get; }
        IWorkItem Dequeue();
        void Enqueue(IWorkItem item);
    }
}
