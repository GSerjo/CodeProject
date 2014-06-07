using System;
using System.Threading;
using Zulu.Threading.ThreadPools;
using Zulu.Threading.ThreadPools.TaskItems;
using log4net;
using log4net.Config;

namespace DefaultQueueSample
{
    internal sealed class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Program));
        private static IExtendedThreadPool _threadPool;

        private static void Main()
        {
            XmlConfigurator.Configure();
            _threadPool = new ExtendedThreadPool.Builder().Build();
            AddTasks();
            Console.ReadKey();
        }

        private static void AddTasks()
        {
            for (int taskIndex = 0; taskIndex < 10; taskIndex++)
            {
                _threadPool.AddTask(new SampleTask(taskIndex));
            }
        }

        private sealed class SampleTask : ITaskItem
        {
            private readonly int _taskIndex;

            public SampleTask(int taskIndex)
            {
                _taskIndex = taskIndex;
            }

            public void DoWork()
            {
                Thread.Sleep(1000);
                _log.InfoFormat("Task {0} has been finished", _taskIndex);
            }
        }
    }
}
