using System;
using System.Threading;
using Zulu.Threading.ThreadPools;
using Zulu.Threading.ThreadPools.TaskItems;
using Zulu.Threading.ThreadPools.TaskQueueControllers;
using Zulu.Threading.ThreadPools.TaskQueues;
using log4net;
using log4net.Config;

namespace PriorityQueueSample
{
    internal sealed class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Program));
        private static IExtendedThreadPool _threadPool;

        private static void AddTasks()
        {
            int maxPriority = Enum.GetValues(typeof(TaskItemPriority)).Length;
            for (int taskIndex = 0; taskIndex < 15; taskIndex++)
            {
                var priority = (TaskItemPriority)new Random().Next(maxPriority);
                _threadPool.AddTask(new SampleTask(taskIndex, priority), priority);
                Thread.Sleep(100);
            }
        }

        private static void Main()
        {
            XmlConfigurator.Configure();
            _threadPool = new ExtendedThreadPool.Builder
                {
                    TaskQueueController = new DefaultTaskQueueController(new PriorityTaskQueue())
                }.Build();

            AddTasks();
            _threadPool.Stop();
            Console.ReadKey();
        }

        private sealed class SampleTask : ITaskItem
        {
            private readonly TaskItemPriority _priority;
            private readonly int _taskIndex;

            public SampleTask(int taskIndex, TaskItemPriority priority)
            {
                _taskIndex = taskIndex;
                _priority = priority;
            }

            public void DoWork()
            {
                Thread.Sleep(1000);
                _log.InfoFormat("Task {0}, priority: {1} has been finished", _taskIndex, _priority);
            }
        }
    }
}
