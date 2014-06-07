using System;
using System.Messaging;
using log4net;

namespace Zulu.Threading.ThreadPools.TaskItems
{
    public abstract class TransactionalMsmqTaskItem<T> : ITaskItem
        where T : class
    {
        private readonly ILog _log;
        private readonly MessageQueue _queue;

        protected TransactionalMsmqTaskItem(MessageQueue queue)
        {
            if (queue == null)
            {
                throw new ArgumentNullException();
            }
            _queue = queue;
            _log = LogManager.GetLogger(GetType());
        }

        public void DoWork()
        {
            try
            {
                T message = null;
                TimeSpan messageReceiveTimeout = TimeSpan.FromMilliseconds(500);
                using (var transaction = new MessageQueueTransaction())
                {
                    try
                    {
                        transaction.Begin();
                        Message msmqMessage = _queue.Receive(messageReceiveTimeout, transaction);

                        if (msmqMessage != null)
                        {
                            message = msmqMessage.Body as T;

                            if (message == null)
                            {
                                string messageType = msmqMessage.Body != null
                                    ? msmqMessage.Body.GetType().Name
                                    : "<null>";
                                _log.Warn(
                                    string.Format(
                                        "Message of a wrong type was received (expected {0} but was {1}",
                                        typeof(T).Name,
                                        messageType));
                            }
                            else
                            {
                                Perform(message);
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Abort();
                        _log.Error(ex);
                        AbortDoWork(transaction, message);
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }

        protected virtual void AbortDoWork(MessageQueueTransaction transaction, T message)
        {
            transaction.Abort();
        }

        protected abstract void Perform(T value);
    }
}
