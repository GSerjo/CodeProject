﻿namespace Zulu.Threading.ThreadPools.TaskItems
{
    public interface IWorkItem : ITaskItem
    {
        TaskItemPriority Priority { get;}
    }
}
