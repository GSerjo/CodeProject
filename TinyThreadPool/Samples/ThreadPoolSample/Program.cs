using System;
using System.Threading;
using Nelibur.Sword.Threading.ThreadPools;
using Nelibur.Sword.Threading.ThreadPools.TaskItems;

namespace ThreadPoolSample
{
    internal class Program
    {
        private static ITinyThreadPool _threadPool;

        private static void AddTasks()
        {
            for (int taskIndex = 0; taskIndex < 50; taskIndex++)
            {
                _threadPool.AddTask(new SampleTask(taskIndex));
            }
        }

        private static void Main()
        {
            // create default TinyThreadPool instance or thru method TinyThreadPool.Create
            // _threadPool = TinyThreadPool.Default;

            _threadPool = TinyThreadPool.Create(x =>
            {
                x.Name = "My ThreadPool";
                x.MinThreads = 2;
                x.MaxThreads = 10;
                x.MultiThreadingCapacity = MultiThreadingCapacity.Global;
            });

            AddTasks();
            Console.ReadKey();
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
                Thread.Sleep(100);
                Console.WriteLine("Task {0} has been finished", _taskIndex);
            }
        }
    }
}
