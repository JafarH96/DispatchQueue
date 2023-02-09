using System;
using System.Threading.Tasks;
using System.Threading;

namespace DispatchQueue
{
    public class DispatchQueue
    {
        private Task queue;
        private CancellationTokenSource cancellationTokenSource;

        public static DispatchQueue main = new DispatchQueue();

        public DispatchQueue()
        {
            cancellationTokenSource = new CancellationTokenSource();
            queue = new Task(() => { }, cancellationTokenSource.Token, TaskCreationOptions.RunContinuationsAsynchronously);
            queue.Start();
        }

        public async void Async(Action<Task> action)
        {
            await queue.ContinueWith(action);
        }

        public void Sync(Action<Task> action)
        {
            queue.ContinueWith(action);
        }
    }
}
